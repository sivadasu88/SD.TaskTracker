using System;

namespace SD.TaskTracker.Data.Model
{
    public class Tasks
    {
        public string TaskName { set; get; }
        public string TaskDescription { set; get; }
        public string TaskOwnerID { set; get; }
        public string SprintID { set; get; }
        public string FeatureID { set; get; }
        public string ProjectID { set; get; }
        public string CurrentStatus { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime LastModifiedDate { set; get; }
        public string LastModifiedBy { set; get; }
    }
}
