using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Language
    {
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessageResourceName = "MaxLength20", ErrorMessageResourceType = typeof(StaticResource.Resources))]     
        public string Symbol { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}