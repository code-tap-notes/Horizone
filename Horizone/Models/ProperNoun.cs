using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class ProperNoun
    {
        public int Id { get; set; }

        [Display(Name = "ThemeStory", ResourceType = typeof(StaticResource.Resources))]
        public string Source { get; set; }
    }
}