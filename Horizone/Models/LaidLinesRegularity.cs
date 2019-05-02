using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class LaidLinesRegularity
    {
        public int Id { get; set; }

        [Display(Name = "LaidLinesRegularity", ResourceType = typeof(StaticResource.Resources))]
        public string LaidLinesRegularityEn { get; set; }

        [Display(Name = "LaidLinesRegularity", ResourceType = typeof(StaticResource.Resources))]
        public string LaidLinesRegularityFr { get; set; }

        [Display(Name = "LaidLinesRegularity", ResourceType = typeof(StaticResource.Resources))]
        public string LaidLinesRegularityZh { get; set; }
    }
}