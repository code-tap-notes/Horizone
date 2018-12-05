using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class TextContent
    {
        public int Id { get; set; }

        [Display(Name = "Titre de l'oeuvre / Title of the work")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 2 Characters")]
        public string TitleOfTheWork { get; set; }


        [Display(Name = "Passage")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 2 Characters")]
        public string Passage { get; set; }


        [Display(Name = "Genre de texte / Text genre")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 2 Characters")]
        public string TextGenre { get; set; }

        [Display(Name = "Sous-genre du texte / Text Subgenre")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 2 Characters")]
        public string TextSubgenre { get; set; }

        [Display(Name = "Verset-Prose /Verse-Prose")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 2 Characters")]
        public string VerseProse { get; set; }

        public ICollection<Manuscript> Manuscripts { get; set; }
    }
}