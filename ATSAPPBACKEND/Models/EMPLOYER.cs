using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("EMPLOYER")]
    public class EMPLOYER
    {
        [Key]
        public int EMPLOYERID { get; set; }
        public string EMPLOYERNAME { get; set; }
        public DateTime? EMPLOYERCD { get; set; }
        public TimeSpan? EMPLOYERCT { get; set; }
        public DateTime? EMPLOYERUD { get; set; }
        public TimeSpan? EMPLOYERUT { get; set; }
        public int EMPLOYERCOMPANY { get; set; }
        public string EMPLOYEREMAIL { get; set; }
        public string EMPLOYERPHONENUMBER { get; set; }
        public string ActiveFlag { get; set; }
        public string DeleteFlag { get; set; }
    }

    public class EMPLOYEREXT : EMPLOYER
    {
        public string EMPLOYERCOMPANYNAME { get; set; }
    }
}
