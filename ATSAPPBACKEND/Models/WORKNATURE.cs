using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("WORKNATURE")]
    public class WORKNATURE
    {
        [Key]
        public int WORKNATUREID { get; set; }
        public string WORKNATURENAME { get; set; }
    }
}
