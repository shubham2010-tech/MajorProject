using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrimeMgmnt.Models
{
    [Table(name: "User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} cannot be empty")]
        [MinLength(2, ErrorMessage = "{0} cannot have lesser than {1} characters")]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [Display(Name ="platform of crime")]
        public string CrimePlatform {get; set;}

        [Required]
        [StringLength(50, ErrorMessage = "{0} cannot be empty")]
        [MinLength(5, ErrorMessage = "{0} cannot have lesser than {5} characters")]
        [Display(Name ="Brief description of crime")]
        public String CrimeDescription { get; set; }

        [Required]
        [Display(Name ="Date of Crime")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name ="Current city or state")]
        public string Place { get; set; }

        #region Navigation Properties to the ControlRoom Model

        public ICollection<CyberCell> ControlRooms { get; set; }

        #endregion

    }
}
