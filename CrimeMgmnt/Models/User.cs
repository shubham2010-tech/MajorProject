using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CrimeMgmnt.Models
{
    [Table(name: "Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage ="{0} cannot be empty!")]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="You must enter the registered number")]
        [Display(Name = "Reg. Number")]
        public string mobile { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        //[MinLength(2, ErrorMessage = "{0} cannot have lesser than {2} characters")]
        [Display(Name ="platform of crime")]
        public string CrimePlatform {get; set;}

        [Required]
        [StringLength(50)]
        //[MaxLength(2, ErrorMessage = "{0} cannot have more than {100} characters")]
        [Display(Name ="Brief description of crime")]
        public String CrimeDescription { get; set; }

        [Required]
        [Display(Name ="Date of Crime")]
        public DateTime DateTime { get; set; }

        [Required]
        [Display(Name ="Current city or state")]
        public string Place { get; set; }

        #region Navigation Properties to the ControlRoom Model
        [JsonIgnore]        // It ensures to suppress the informaation about the foreign key realtionship.
        public ICollection<CyberCell> ControlRooms { get; set; }

        #endregion

    }
}
