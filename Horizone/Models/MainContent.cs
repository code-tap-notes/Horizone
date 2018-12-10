using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace Horizone.Models
{
    public class MainContent
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Modifier ")]
        public DateTime DateModifier
        {
            get
            {
                return DateTime.Now;
            }
        }

        [Display(Name = "Qui somme nous?")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 250 caracteres / At least 1 Characters")]
        public string AboutUs { get; set; }

        [Display(Name = "Contact :")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 2 a 50 caracteres / At least 2 Characters")]
        public string Contact { get; set; }

        [Display(Name = "Presentation le page:")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 250 caracteres / At least 1 Characters")]
        public string Title { get; set; }
        
    }
}