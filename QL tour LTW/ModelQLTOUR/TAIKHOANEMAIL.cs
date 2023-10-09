namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOANEMAIL")]
    public partial class TAIKHOANEMAIL
    {
        [Key]
        [StringLength(30)]
        public string LTKEMAIL { get; set; }

        [Required]
        [StringLength(30)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string MKEMAIL { get; set; }

        [Column(TypeName = "image")]
        public byte[] ANHTKEMAIL { get; set; }
    }
}
