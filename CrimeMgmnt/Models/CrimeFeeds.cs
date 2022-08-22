using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrimeMgmnt.Models
{
    [Table(name:"Crime Updates")]
    public class CrimeFeeds
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name =("City"))]
        public string Title { get; set; }

        [Required]
        [Display(Name =("Cases Registered"))]
        public short Cases { get; set; }

        [Required]
        [Display(Name = ("Recent Reports"))]
        public string Crimes { get; set; }

        [Required]
        [Display(Name =("Platform"))]

        public string Platform { get; set; }

    }
}
