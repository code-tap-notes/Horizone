using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class WordSubClass
    {
        public int Id { get; set; }

        [Display(Name = "WordSubClassEn", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string SubClassEn { get; set; }

        [Display(Name = "WordSubClassFr", ResourceType = typeof(StaticResource.Resources))]
        public string SubClassFr { get; set; }

        [Display(Name = "WordSubClassZh", ResourceType = typeof(StaticResource.Resources))]
        public string SubClassZh { get; set; }
       
    }
}