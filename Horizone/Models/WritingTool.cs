using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class WritingTool
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "WritingToolEn", ResourceType = typeof(StaticResource.Resources))]
        public string WritingToolEn { get; set; }

        [AllowHtml]
        [Display(Name = "WritingToolFr", ResourceType = typeof(StaticResource.Resources))]
        public string WritingToolFr { get; set; }

        [AllowHtml]
        [Display(Name = "WritingToolZh", ResourceType = typeof(StaticResource.Resources))]
        public string WritingToolZh { get; set; }
    }
}