using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("TAXTERM")]
    public class TAXTERM
    {
        [Key]
        public int TAXTERMID { get; set; }
        public string TAXTERMNAME { get; set; }
    }
}
