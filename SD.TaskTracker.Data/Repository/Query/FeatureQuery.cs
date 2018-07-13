using SD.TaskTracker.Data.DataContext;
using SD.TaskTracker.Data.Interface.Query;
using SD.TaskTracker.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace SD.TaskTracker.Data.Repository.Query
{
    public class FeatureQuery : IFeatureQuery
    {
        private readonly TaskTrackerReadContext _context;

        //  private readonly IApplicationManagementApiClient _amClient;
        public FeatureQuery(TaskTrackerReadContext context)
        {

            _context = context;


        }
        public List<Feature> Get()
        {
            return _context.Features.ToList();
        }
    }
}
