using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("IMPLEMENTATION")]
    public class IMPLEMENTATION
    {
        [Key]
        public int IMPLEMENTATIONID { get; set; }
        public string IMPLEMENTATIONNAME { get; set; }
        public string ActiveFlag { get; set; }
        public string DeleteFlag { get; set; }
        public DateTime? IMPLEMENTATIONCD { get; set; }
        public TimeSpan? IMPLEMENTATIONCT { get; set; }
        public DateTime? IMPLEMENTATIONUD { get; set; }
        public TimeSpan? IMPLEMENTATIONUT { get; set; }
    }
}
