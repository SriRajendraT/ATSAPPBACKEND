using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("STATE")]
    public class STATE
    {
        [Key]
        public int STATEID { get; set; }
        public string STATENAME { get; set; }
        public int COUNTRYID { get; set; }
    }
}
