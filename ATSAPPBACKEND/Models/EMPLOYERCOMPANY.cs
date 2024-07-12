using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("EMPLOYERCOMPANY")]
    public class EMPLOYERCOMPANY
    {
        [Key]
        public int EMPLOYERCOMPANYID { get; set; }
        public string EMPLOYERCOMPANYNAME { get; set; }
        public DateTime? EMPLOYERCOMPANYCD { get; set; }
        public TimeSpan? EMPLOYERCOMPANYCT { get; set; }
        public DateTime? EMPLOYERCOMPANYUD { get; set; }
        public TimeSpan? EMPLOYERCOMPANYUT { get; set; }
        public string ActiveFlag { get; set; }
        public string DeleteFlag { get; set; }
    }
}
