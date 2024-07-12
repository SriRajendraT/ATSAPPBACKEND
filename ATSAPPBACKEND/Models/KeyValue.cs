using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [NotMapped]
    public class KeyValue
    {
        public int KEY1 { get; set; }
        public int KEY2 { get; set; }
        public int KEY3 { get; set; }
        public string VALUE1 { get; set; }
        public string VALUE2 { get; set; }
        public string VALUE3 { get; set; }
    }
}
