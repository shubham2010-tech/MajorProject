using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrimeMgmnt.Models
{
    [Table(name:"Cyber Updates")]
    public class CyberUpdates
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Recent Updates")]
        public string About { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Safety Tip")]

        public string Description { get; set; }

        public int contact { get; set; }


    }
}
