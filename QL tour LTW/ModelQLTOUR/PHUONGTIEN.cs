namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHUONGTIEN")]
    public partial class PHUONGTIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHUONGTIEN()
        {
            TOURs = new HashSet<TOUR>();
        }

        [Key]
        [StringLength(12)]
        public string MAPT { get; set; }

        [Required]
        [StringLength(50)]
        public string TENPT { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOUR> TOURs { get; set; }
    }
}
