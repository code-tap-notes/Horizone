using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class FiberDistribution
    {
        public int Id { get; set; }

        [Display(Name = "FiberDistribution", ResourceType = typeof(StaticResource.Resources))]
        public string DistributionEn { get; set; }

        [Display(Name = "FiberDistribution", ResourceType = typeof(StaticResource.Resources))]
        public string DistributionFr { get; set; }

        [Display(Name = "FiberDistribution", ResourceType = typeof(StaticResource.Resources))]
        public string DistributionZh { get; set; }

    }
}