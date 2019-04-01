using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Horizone.Models
{
    public class ThemeStory
    {
        public int Id { get; set; }

        [Display(Name = "ThemeStoryEn", ResourceType = typeof(StaticResource.Resources))]
        public string ThemeEn { get; set; }

        [Display(Name = "ThemeStoryFr", ResourceType = typeof(StaticResource.Resources))]
        public string ThemeFr { get; set; }

        [Display(Name = "ThemeStoryZh", ResourceType = typeof(StaticResource.Resources))]
        public string ThemeZn { get; set; }

    }
}