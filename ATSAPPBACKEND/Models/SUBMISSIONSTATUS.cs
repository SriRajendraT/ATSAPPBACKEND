using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("SUBMISSIONSTATUS")]
    public class SUBMISSIONSTATUS
    {
        [Key]
        public int SUBMISSIONSTATUSID { get; set; }
        public string SUBMISSIONSTATUSNAME { get; set; }
    }
}
