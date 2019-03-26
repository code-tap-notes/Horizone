using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Presentation
    {
        public int Id { get; set; }
        [AllowHtml]
        [Display(Name = "AboutUs", ResourceType = typeof(StaticResource.Resources))]
        public string AboutUs { get; set; }

        [AllowHtml]
        [Display(Name = "TochPhrase", ResourceType = typeof(StaticResource.Resources))]
        public string TochPhrase { get; set; }
        [AllowHtml]
        [Display(Name = "TochStory", ResourceType = typeof(StaticResource.Resources))]
        public string TochStory { get; set; }

        [AllowHtml]
        [Display(Name = "Manuscript", ResourceType = typeof(StaticResource.Resources))]
        public string Manuscript { get; set; }

        [AllowHtml]
        [Display(Name = "Activity", ResourceType = typeof(StaticResource.Resources))]
        public string Activity { get; set; }

        [AllowHtml]
        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public string Bibliography { get; set; }

        [AllowHtml]
        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public string DictionaryTocharian { get; set; }

        [AllowHtml]
        [Display(Name = "Help", ResourceType = typeof(StaticResource.Resources))]
        public string VisualAids { get; set; }
    }
}