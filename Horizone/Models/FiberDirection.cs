using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class FiberDirection
    {
        public int Id { get; set; }

        [Display(Name = "FiberDirection", ResourceType = typeof(StaticResource.Resources))]
        public string DirectionEn { get; set; }

        [Display(Name = "FiberDirection", ResourceType = typeof(StaticResource.Resources))]
        public string DirectionFr { get; set; }

        [Display(Name = "FiberDirection", ResourceType = typeof(StaticResource.Resources))]
        public string DirectionZh { get; set; }
    }
}