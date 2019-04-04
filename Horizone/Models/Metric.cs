using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Metric
    {
        public int Id { get; set; }

        [Display(Name = "MetricEn", ResourceType = typeof(StaticResource.Resources))]
        public string MetricEn { get; set; }
        [Display(Name = "MetricFr", ResourceType = typeof(StaticResource.Resources))]
        public string MetricFr { get; set; }
        [Display(Name = "MetricZh", ResourceType = typeof(StaticResource.Resources))]
        public string MetricZh { get; set; }

    }
}