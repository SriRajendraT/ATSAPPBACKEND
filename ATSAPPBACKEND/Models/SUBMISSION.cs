using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("SUBMISSION")]
    public class SUBMISSION
    {
        [Key]
        public int SUBMISSIONID { get; set; }
        public int REQUIREMENTID { get; set; }
        public int CANDIDATEID { get; set; }
        public int SUBMISSIONSTATUSID { get; set; }
        public DateTime? SUBMISSIONCD { get; set; }
        public TimeSpan? SUBMISSIONCT { get; set; }
        public DateTime? SUBMISSIONUD { get; set; }
        public TimeSpan? SUBMISSIONUT { get; set; }
        public string ActiveFlag { get; set; }
        public string DeleteFlag { get; set; }
    }

    public class SUBMISSIONEXT : SUBMISSION
    {
        public string REQUIREMENTNAME { get; set; }
        public string CANDIDATENAME { get; set; }
        public string SUBMISSIONSTATUSNAME { get; set; }
    }
}
