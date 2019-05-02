using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class ChainLinesVisibility
    {
        public int Id { get; set; }

        [Display(Name = "ChainLinesVisibility", ResourceType = typeof(StaticResource.Resources))]
        public string ChainLinesVisibilityEn { get; set; }

        [Display(Name = "ChainLinesVisibility", ResourceType = typeof(StaticResource.Resources))]
        public string ChainLinesVisibilityFr { get; set; }

        [Display(Name = "ChainLinesVisibility", ResourceType = typeof(StaticResource.Resources))]
        public string ChainLinesVisibilityZh { get; set; }
        
    }
}