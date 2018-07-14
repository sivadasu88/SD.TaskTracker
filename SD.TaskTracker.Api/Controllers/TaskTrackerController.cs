using Microsoft.AspNetCore.Mvc;
using SD.TaskTracker.Domain.Interface;
using SD.TaskTracker.Domain.Model;
using System.Collections.Generic;

namespace SD.TaskTracker.Api.Controllers
{
    [Route("tasktracker")]
    // [Authorize]
    public class TaskTrackerController : Controller
    {
        private readonly IFeatureProvider _featureProvider;
        public TaskTrackerController(IFeatureProvider featureProvider)
        {

            _featureProvider = featureProvider;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Feature> Get()
        {
            return _featureProvider.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
