using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("CITY")]
    public class CITY
    {
        [Key]
        public int CITYID { get; set; }
        public string CITYNAME { get; set; }
        public int STATEID { get; set; }

    }
}
