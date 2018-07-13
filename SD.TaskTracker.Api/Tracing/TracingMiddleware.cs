using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD.TaskTracker.Web.Api.Tracing
{
    /// <summary>
    /// Middleware to provide tracing functionality
    /// </summary>
    public class TracingMiddleware
    {
        private const string CorrelationIdHeader = "x-correlation-id";
        private readonly RequestDelegate _next;
        private readonly ILogger<TracingMiddleware> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TracingMiddleware"/> class
        /// </summary>
        /// <param name="next">The request delegate to use to continue the pipeline</param>
        public TracingMiddleware(RequestDelegate next, ILogger<TracingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var correlationId = GetOrGenerateCorrelationId(context);
            AddCorrelationIdToResponseHeaders(context, correlationId);
            var requestId = Guid.NewGuid().ToString();
            context.TraceIdentifier = requestId;
            LogContext.PushProperty("RequestId", requestId);
            LogContext.PushProperty("CorrelationId", correlationId);
            await _next(context);
        }

        public string GetOrGenerateCorrelationId(HttpContext context)
        {
            string correlationId;
            var key = context.Request.Headers.Keys.FirstOrDefault(n => n.Equals(CorrelationIdHeader, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(key))
            {
                List<string> keys = (List<string>)context.Request.Headers.Keys;
                correlationId = keys[0];
            }
            else
            {
                correlationId = Guid.NewGuid().ToString();
                AddCorrelationIdToRequestHeaders(context, correlationId);
                _logger.LogInformation("Generated new CorrelationId: {@CorrelationId}", correlationId);
            }

            return correlationId;
        }

        private void AddCorrelationIdToResponseHeaders(HttpContext context, string correlationId)
        {
            context.Response.Headers.Append(CorrelationIdHeader, correlationId);
        }

        private void AddCorrelationIdToRequestHeaders(HttpContext context, string correlationId)
        {
            context.Request.Headers.Append(CorrelationIdHeader, correlationId);
        }
    }

    public static class CorrelationIdExtension
    {
        public static IApplicationBuilder UseCorrelationId(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TracingMiddleware>();
        }
    }
}
