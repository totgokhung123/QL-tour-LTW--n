namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(30)]
        public string LTK { get; set; }

        [Required]
        [StringLength(30)]
        public string TENTAIKHOAN { get; set; }

        [Required]
        [StringLength(50)]
        public string MATKHAU { get; set; }

        [Column(TypeName = "image")]
        public byte[] ANHTK { get; set; }
    }
}
