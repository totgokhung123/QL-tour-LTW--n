namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHSAN")]
    public partial class KHACHSAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHSAN()
        {
            TOURs = new HashSet<TOUR>();
        }

        [Key]
        [StringLength(12)]
        public string MAKS { get; set; }

        [Required]
        [StringLength(50)]
        public string TENKS { get; set; }

        [Required]
        [StringLength(100)]
        public string DIACHI { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOUR> TOURs { get; set; }
    }
}
