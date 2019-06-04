using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class TenseAndAspect
    {
        public int Id { get; set; }

        [Display(Name = "Abbreviations", ResourceType = typeof(StaticResource.Resources))]
        public string Tense { get; set; }

        [Display(Name = "Tense", ResourceType = typeof(StaticResource.Resources))]
        public string TenseEn { get; set; }

        [Display(Name = "Tense", ResourceType = typeof(StaticResource.Resources))]
        public string TenseFr { get; set; }

        [Display(Name = "Tense", ResourceType = typeof(StaticResource.Resources))]
        public string TenseZh { get; set; }

    }
}