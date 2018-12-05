using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class TochStory
    {
        public int Id { get; set; }

        [Display(Name = "Nom d'histoire / Story name")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Name { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [Display(Name = "Content")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string ContentEnglish { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [Display(Name = "Contenu")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string ContentFrancaise { get; set; }

        [AllowHtml]        
        [Display(Name = "内容")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string ContentChinese { get; set; }

        [AllowHtml]       
        [Display(Name = "Nội dung")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string ContentVietnam { get; set; }

        [AllowHtml]
        public string Description { get; set; }
    }
}