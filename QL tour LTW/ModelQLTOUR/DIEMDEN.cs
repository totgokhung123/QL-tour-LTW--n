namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEMDEN")]
    public partial class DIEMDEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DIEMDEN()
        {
            TOURs = new HashSet<TOUR>();
        }

        [Key]
        [StringLength(12)]
        public string MADDEN { get; set; }

        [Required]
        [StringLength(50)]
        public string TENDDEN { get; set; }

        [Required]
        [StringLength(5)]
        public string MALTOUR { get; set; }

        public virtual LOAITOUR LOAITOUR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TOUR> TOURs { get; set; }
    }
}
