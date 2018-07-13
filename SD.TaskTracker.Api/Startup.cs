using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using SD.TaskTracker.Web.Api.Tracing;
using System;

namespace SD.TaskTracker.Api
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(env.ContentRootPath)

            .AddJsonFile($"appsettings.json", optional: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ConfigureSecurity(services);
            services.AddMvc();
            services.AddMvcCore()
          //  .AddAuthorization()
          .AddJsonFormatters();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //  app.UseAuthentication();
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            contentTypeProvider.Mappings[".yaml"] = "text/x-yaml";
            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = contentTypeProvider
            });
            var swaggerEndpointUrl = "/Swagger/v1.yaml";
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint(swaggerEndpointUrl, "v1");
            });
            app.UseCorrelationId();
            app.UseMvc();
        }
        private void ConfigureSecurity(IServiceCollection services)
        {
            var authSettings = Configuration.GetSection("Authorization");
            services.AddMvc(options =>
            {
                options.AllowEmptyInputInBodyModelBinding = true;
                //var policy = new AuthorizationPolicyBuilder()
                //    .RequireAuthenticatedUser()
                //    .Build();
                //options.Filters.Add(new AuthorizeFilter(policy));

            })
            .AddFluentValidation()
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter
                {
                    CamelCaseText = true
                });
            });
            services.Configure<IdentityServerClientConfig>(Configuration.GetSection("TaskTrackerIdentityServer"));

            var domain = authSettings["IdentityServerUrl"];

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = domain;
                options.RequireHttpsMetadata = domain.StartsWith("https://", StringComparison.OrdinalIgnoreCase);
                options.ApiName = authSettings["ClientKey"];
                options.ApiSecret = authSettings["ClientSecret"];
                options.EnableCaching = true;
                options.LegacyAudienceValidation = true;
            });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy(PolicyNames.ReadPermissions, policy => policy.Requirements.Add(new PermissionsReadRequirement(domain)));
            //    options.AddPolicy(PolicyNames.WritePermissions, policy => policy.Requirements.Add(new PermissionsWriteRequirement(domain)));
            //});
        }
    }
}
