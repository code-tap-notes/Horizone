using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Valency
    {
        public int Id { get; set; }

        [Display(Name = "Valency", ResourceType = typeof(StaticResource.Resources))]
        public string AbbreviationValency { get; set; }

        [Display(Name = "ValencyEn", ResourceType = typeof(StaticResource.Resources))]
        public string ValencyEn { get; set; }

        [Display(Name = "ValencyFr", ResourceType = typeof(StaticResource.Resources))]
        public string ValencyFr { get; set; }

        [Display(Name = "ValencyZh", ResourceType = typeof(StaticResource.Resources))]
        public string ValencyZh { get; set; }

    }
}