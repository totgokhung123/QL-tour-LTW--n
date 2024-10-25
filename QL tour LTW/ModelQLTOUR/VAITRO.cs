using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_tour_LTW.ModelQLTOUR
{
    [Table("VAITRO")]
    public class VAITRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VAITRO()
        {
            TKUSERs = new HashSet<TKUSER>();
        }

        [Key]
        [StringLength(50)]
        public string MAVAITRO { get; set; }

        [Required]
        [StringLength(150)]
        public string TENVAITRO { get; set; }

        [StringLength(150)]
        public string CHUCNANG { get; set; }

        public virtual ICollection<TKUSER> TKUSERs { get; set; }
    }
}
