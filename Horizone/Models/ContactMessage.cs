using Horizone.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Display(Name = "M/Mme/Mrs/Miss")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.  / Field {0} is required")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 à 20 caractères / At least 1 Character")]		
        public string Title { get; set; }

        [Display(Name = "Nom / Last name")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.  / Field {0} is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Le champ doit avoir de 2 à 30 caractères / At least 2 Character")]	
        public string LastName { get; set; }

        [Display(Name = "Prénom / First Name")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.  / Field {0} is required")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "La prénom doit avoir de 2 à 30 caractères / At least 2 Character")]		
        public string FisrtName { get; set; }

        [Required]
        [Display(Name = "Courrier électronique /Email")]
        public string Email { get; set; }

        [Display(Name = "Téléphone ")]       
        [RegularExpression(@"^([0-9])*\s*$")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Le champ telephone doit avoir de 3 à 20 caractères / At least 3 Character")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Date envoi / Send date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Le champ {0} est obligatoire.  / Field {0} is required")]
        [Column(TypeName ="datetime2")]       
        public DateTime SendDate { get; set; }

        [AllowHtml]
        public string Message { get; set; }

    }
}