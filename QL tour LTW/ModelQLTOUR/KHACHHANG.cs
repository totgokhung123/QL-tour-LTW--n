namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(11)]
        public string MAKH { get; set; }

        [Required]
        [StringLength(32)]
        public string HO { get; set; }

        [Required]
        [StringLength(11)]
        public string TEN { get; set; }

        [Required]
        [StringLength(13)]
        public string SDT { get; set; }

        [Required]
        [StringLength(13)]
        public string CCCD { get; set; }

        [Required]
        [StringLength(254)]
        public string EMAIL { get; set; }

        public int? SL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
