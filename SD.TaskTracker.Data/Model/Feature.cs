using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SD.TaskTracker.Data.Model
{
    [Table("Feature")]
    public class FeatureRecord
    {
        public string FeatureName { set; get; }
        public string FeatureDescription { set; get; }
        public int ProjectID { set; get; }
        public int SprintID { set; get; }
        public string Tags { set; get; }
        public string RankID { set; get; }
        public string FeatureOwnerID { set; get; }
        [Column("CreatedTimeStamp")]
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        [Column("LastModifiedTimeStamp")]
        public DateTime LastModifiedDate { set; get; }
        public string LastModifiedBy { set; get; }
    }
}
