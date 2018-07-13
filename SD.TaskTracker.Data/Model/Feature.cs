using SD.TaskTracker.Common;
using System;

namespace SD.TaskTracker.Data.Model
{
    public class Feature
    {
        public string FeatureName { set; get; }
        public string FeatureDescription { set; get; }
        public int ProjectID { set; get; }
        public int SprintID { set; get; }
        public Tag[] Tags { set; get; }
        public string RankID { set; get; }
        public string FeatureOwnerID { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime LastModifiedDate { set; get; }
        public string LastModifiedBy { set; get; }
    }
}
