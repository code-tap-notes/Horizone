using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Drying
    {
        public int Id { get; set; }

        [Display(Name = "Drying", ResourceType = typeof(StaticResource.Resources))]
        public string DryingEn { get; set; }

        [Display(Name = "Drying", ResourceType = typeof(StaticResource.Resources))]
        public string DryingFr { get; set; }

        [Display(Name = "Drying", ResourceType = typeof(StaticResource.Resources))]
        public string DryingZh { get; set; }

    }
}