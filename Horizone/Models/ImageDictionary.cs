using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class ImageDictionary
    {

        public int Id { get; set; }

        [Display(Name = "Nom / Name")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire./ Field {0} is required")]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string ContentType { get; set;}

        [Required(ErrorMessage = "Vous devez choisir une image./ you have to chose one picture")]
        public byte[] Content { get; set; } 

        [Display(Name= "DictionaryTocharian")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire./ Field {0} is required")]
        public int DictionaryTocharianId { get; set; }

        [ForeignKey("DictionaryTocharianId")]
        public DictionaryTocharian DictionaryTocharian { get; set; }
    }
}