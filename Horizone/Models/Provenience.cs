using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Provenience
    {
        public int Id { get; set; }
        [Display(Name = "Lieu de découverte principal/ Main Find Spot")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Characters")]
        public string MainFindSpot { get; set; }


        [Display(Name = "Lieu de recherche spécifique/ Specific Find Spot")]       
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Characters")]
        public string SpecificFindSpot { get; set; }



        [Display(Name = "Code d'expédition / Expedition Code")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Characters")]
        public string ExpeditionCode { get; set; }

        [Display(Name = "Colection")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Characters")]
        public string Colection { get; set; }

        public ICollection<Manuscript> Manuscripts { get; set; }
       

    }
}