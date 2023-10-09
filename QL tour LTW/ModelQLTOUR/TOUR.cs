namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOUR")]
    public partial class TOUR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOUR()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(11)]
        public string MATOUR { get; set; }

        [Required]
        [StringLength(150)]
        public string TENTOUR { get; set; }

        public decimal GIATOUR { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYDI { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYKETTHUC { get; set; }

        [StringLength(400)]
        public string MOTA { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        [Required]
        [StringLength(5)]
        public string MALTOUR { get; set; }

        [Required]
        [StringLength(12)]
        public string MADDI { get; set; }

        [Required]
        [StringLength(12)]
        public string MADDEN { get; set; }

        [StringLength(12)]
        public string MAPT { get; set; }

        [StringLength(12)]
        public string MAKS { get; set; }

        [Column(TypeName = "image")]
        public byte[] ANH1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] ANH2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] ANH3 { get; set; }

        public virtual DIEMDEN DIEMDEN { get; set; }

        public virtual DIEMDI DIEMDI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        public virtual KHACHSAN KHACHSAN { get; set; }

        public virtual LOAITOUR LOAITOUR { get; set; }

        public virtual PHUONGTIEN PHUONGTIEN { get; set; }
    }
}
