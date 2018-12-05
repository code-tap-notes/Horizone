using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace Horizone.Models
{
    public class ObjectManuscript
    {
        public int Id { get; set; }

        [Display(Name = "Manuscript")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Manuscript { get; set; }


        [Display(Name = "Nombre de feuilles / Leaf Number")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string LeafNumber { get; set; }


        [Display(Name = "Matériel / Material")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Material { get; set; }

        [Display(Name = "laforme / Form")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Form { get; set; }

        [Display(Name = "Le Nombre de lignes / Number of lines")]
        [Range(0, 1000, ErrorMessage = "Le Nombre de lignes doit être positif / field has to be possitive")]
        public int NumberOfLine { get; set; }

        public ICollection<Manuscript> Manuscripts { get; set; }
    }
}