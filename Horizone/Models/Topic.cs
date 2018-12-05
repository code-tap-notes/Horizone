using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Display(Name = "Sujet")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le Sujet doit avoir de 1 a 40 caracteres / At least 1 character")]
        public string NameFrench { get; set; }

        [Display(Name = "Topic")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le Sujet doit avoir de 1 a 40 caracteres / At least 1 character")]
        public string NameEnglish { get; set; }

        [Display(Name = "话题")]       
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le Sujet doit avoir de 1 a 40 caracteres / At least 1 character")]
        public string TopicChinese { get; set; }

        [Display(Name = "Thể loại")]       
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le Sujet doit avoir de 1 a 40 caracteres / At least 1 character")]
        public string TopicVietnam { get; set; }

    }
}