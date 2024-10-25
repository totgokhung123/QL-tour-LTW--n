namespace QL_tour_LTW.ModelQLTOUR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TKUSER")]
    public partial class TKUSER
    {
        [Key]
        [StringLength(150)]
        public string TENTAIKHOAN { get; set; }

        [Required]
        [StringLength(50)]
        public string MATKHAU { get; set; }

        [StringLength(50)]
        public string MAVAITRO { get; set; }

        [Column(TypeName = "image")]
        public byte[] ANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual VAITRO VAITRO { get; set; }
    }
}
