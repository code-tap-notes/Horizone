using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ImageNews
    {
        public int Id { get; set; }

        [Display(Name = "Nom /Name")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ContentType { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Vous devez choisir une image. / You have to chose one picture")]
        public byte[] Content { get; set; }

        [Display(Name = "Text in Manuscript")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire./ Field {0} is required")]
        public int NewsId { get; set; }

        [ForeignKey("NewsId")]
        public News News { get; set; }
    }
}