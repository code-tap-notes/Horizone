using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class WordClass
    {
        public int Id { get; set; }

        [Display(Name = "WordClass", ResourceType = typeof(StaticResource.Resources))]
        public string Class { get; set; }


        [Display(Name = "WordClassEn", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string ClassEn { get; set; }

        [Display(Name = "WordClassFr", ResourceType = typeof(StaticResource.Resources))]
        public string ClassFr { get; set; }

        [Display(Name = "WordClassZh", ResourceType = typeof(StaticResource.Resources))]       
        public string ClassZh { get; set; }

    }
}