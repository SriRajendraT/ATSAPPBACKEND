using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("COUNTRY")]
    public class COUNTRY
    {
        [Key]
        public int COUNTRYID { get; set; }
        public string COUNTRYNAME { get; set; }
    }
}
