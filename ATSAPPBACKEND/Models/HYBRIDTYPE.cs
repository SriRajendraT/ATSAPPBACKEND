using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("HYBRIDTYPE")]
    public class HYBRIDTYPE
    {
        [Key]
        public int HYBRIDTYPEID { get; set; }
        public string HYBRIDTYPENAME { get; set; }
    }
}
