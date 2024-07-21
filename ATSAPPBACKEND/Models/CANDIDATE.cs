using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATSAPPBACKEND.Models
{
    [Table("CANDIDATE")]
    public class CANDIDATE
    {
        [Key]
        public int CANDIDATEID { get; set; }
        public string CANDIDATEFULLNAME { get; set; }
        public DateTime? CANDIDATECD { get; set; }
        public TimeSpan? CANDIDATECT { get; set; }
        public DateTime? CANDIDATEUD { get; set; }
        public TimeSpan? CANDIDATEUT { get; set; }
        public string CANDIDATEEMAIL { get; set; }
        public string CANDIDATEPHONE { get; set; }

        [Column("CANDIDATECOUNRTY")]
        public int CANDIDATECOUNTRY { get; set; }

        [Column("CANDIDATESTATE")]
        public int CANDIDATESTATE { get; set; }

        [Column("CANDIDATECITY")]
        public int CANDIDATECITY { get; set; }
        public string CANDIDATEADDRESS { get; set; }
        public int CANDIDATEGENDER { get; set; }
        public int CANDIDATEVISA { get; set; }
        public int CANDIDATETAXTERM { get; set; }
        public int CANDIDATEEMPLOYER { get; set; }
        public decimal CANDIDATERATE { get; set; }

        [Column("VISADATEOFISSUE")]
        public DateTime? VISADATEOFISSUE { get; set; }

        [Column("VISAVALIDUPTO")]
        public DateTime? VISAVAILDUPTO { get; set; }
        public string ActiveFlag { get; set; }
        public string DeleteFlag { get; set; }
    }

    public class CANDIDATEEXT :CANDIDATE
    {
        public string CANDIDATEVISANAME { get; set; }
        public string CANDIDATEGENDERNAME { get; set; }
        public string CANDIDATELOCCOUNTRYNAME { get; set; }
        public string CANDIDATELOCSTATENAME { get; set; }
        public string CANDIDATELOCCITYNAME { get; set; }
        public string CANDIDATEEMPLOYERNAME { get; set; }
        public string CANDIDATETAXTERMNAME { get; set; }
    }
}
