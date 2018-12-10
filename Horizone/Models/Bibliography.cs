using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Bibliography
    {
        public int Id { get; set; }

        [Display(Name = "Author name/ Auteur")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Characters")]
        public string Author { get; set; }


        [Display(Name = "Year of publication")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 2 a 10 caracteres / At least 2 Characters")]
        public string PublicationDate { get; set; }



        [Display(Name = "Title / Titre")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 250 caracteres / At least 1 Character")]
        public string Title { get; set; }

        [Display(Name = "Journal")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 100 caracteres / At least 1 Character")]
        public string Journal { get; set; }

        [Display(Name = "Link")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 250 caracteres / At least 1 Character")]
        public string UlrBibliography { get; set; }
        
    }
}