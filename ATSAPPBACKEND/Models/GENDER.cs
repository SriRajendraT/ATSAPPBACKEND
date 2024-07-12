using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("GENDER")]
    public class GENDER
    {
        [Key]
        public int GENDERID { get; set; }
        public string GENDERNAME { get; set;}
    }
}
