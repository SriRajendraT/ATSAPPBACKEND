using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("REQUIREDVISA")]
    public class REQUIREDVISA
    {
        public int REQUIREDVISAID { get; set; }
        public int REQUIREMENTID { get; set; }
        public int VISAID { get; set; }
    }

    public class REQUIREDVISAExt : REQUIREDVISA
    {
        public string REQUIREMENTTITLE { get; set; }
        public string VISANAME { get; set; }
    }

    public class ReqVisa
    {
        public REQUIREMENTEXT req;
        public List<VISA> visas;
    }
}
