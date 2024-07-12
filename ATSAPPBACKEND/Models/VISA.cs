using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("VISA")]
    public class VISA
    {
        [Key]
        public int VISAID { get; set; }
        public string VISANAME { get; set; }
    }
}
