using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("CLIENT")]
    public class CLIENT
    {
        [Key]
        public int CLIENTID { get; set; }
        public string CLIENTNAME { get; set; }
        public string ActiveFlag { get; set; }
        public string DeleteFlag { get; set; }
        public DateTime? CLIENTCD { get; set; }
        public TimeSpan? CLIENTCT { get; set; }
        public DateTime? CLIENTUD { get; set; }
        public TimeSpan? CLIENTUT { get; set; }
    }
}
