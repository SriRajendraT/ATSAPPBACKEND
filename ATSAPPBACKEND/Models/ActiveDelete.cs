using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [NotMapped]
    public static class ActiveDelete
    {
        public static string Yes="Y";
        public static string No = "N";
    }
}
