using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
	public class Client : Personne
	{
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]        
        [NotMapped]
        public string EmailDisplay { get; set; }
    }
}