using System;

namespace SD.TaskTracker.Data.Model
{
    public class Sprint
    {
        public string SprintID { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public DateTime LastModifiedDate { set; get; }
        public string LastModifiedBy { set; get; }
    }
}
