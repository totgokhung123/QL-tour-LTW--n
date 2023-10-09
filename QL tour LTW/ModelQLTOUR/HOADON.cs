namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [StringLength(12)]
        public string SOHD { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYLAP { get; set; }

        public decimal THANHTIEN { get; set; }

        [Required]
        [StringLength(11)]
        public string MATOUR { get; set; }

        [Required]
        [StringLength(11)]
        public string MAKH { get; set; }

        [Required]
        [StringLength(11)]
        public string MANV { get; set; }

        [StringLength(30)]
        public string TRANGTHAI { get; set; }

        public virtual TOUR TOUR { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
