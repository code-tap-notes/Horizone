using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class DictionaryTocharian
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]       
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Word { get; set; }

        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [Display(Name = "English")]       
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string English { get; set; }


        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [Display(Name = "Francaise")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Francaise { get; set; }

        [Display(Name = "संस्कृतम्")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Sanskrit { get; set; }

        [Display(Name = "中文")]        
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres/ At least 1 Character")]
        public string Chinois { get; set; }

        [Display(Name = "Việt Nam")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Vietnam { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        
        public ICollection<ImageDictionary> ImageDictionarys { get; set; }
       
    }
}