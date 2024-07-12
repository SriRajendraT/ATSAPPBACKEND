using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("REQUIREMENT")]
    public class REQUIREMENT
    {
        [Key]
        public int REQUIREMENTID { get; set; }
        public string REQUIREMENTTITLE { get; set; }
        public string REQUIREMENTDESC { get; set; }
        public DateTime? REQUIREMENTCD { get; set; }
        public TimeSpan? REQUIREMENTCT { get; set; }
        public DateTime? REQUIREMENTUD { get; set; }
        public TimeSpan? REQUIREMENTUT { get; set; }
        public decimal REQUIREMENTMAXRATE { get; set; }
        public int REQUIREMENTLOCCITY { get; set; }
        public int REQUIREMENTWN { get; set; }
        public int REQUIREMENTHYBRIDTYPE { get; set; }
        public int REQUIREMENTIMPLEMENTATION { get; set; }
        public int REQUIREMENTCLIENT { get; set; }
        public string ActiveFlag { get; set; }
        public string DeleteFlag { get; set; }
        public int REQUIREMENTLOCSTATE { get; set; }
        public int REQUIREMENTLOCCOUNTRY { get; set; }
    }

    public class REQUIREMENTEXT : REQUIREMENT
    {
        public string REQUIREMENTLOCCITYNAME { get; set; }
        public string REQUIREMENTLOCSTATENAME { get; set; }
        public string REQUIREMENTLOCCOUNTRYNAME { get; set; }
        public string REQUIREMENTWNNANME { get; set; }
        public string REQUIREMENTHYBRIDTYPENAME { get; set; }
        public string REQUIREMENTIMPLEMENTATIONNAME { get; set; }
        public string REQUIREMENTCLIENTNAME { get; set; }
    }
}
