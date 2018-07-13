using System;

namespace SD.TaskTracker.Data.Model
{
    public class Project
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime LastModifiedDate { set; get; }
        public string LastModifiedBy { set; get; }


    }
}
