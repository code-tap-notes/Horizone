using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Colaborateur : Personne
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire. /Field {0} is required")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<News> Newss { get; set; }
    }
}