using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class RemarkAdd
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "RemarkEn", ResourceType = typeof(StaticResource.Resources))]
        public string RemarkEn { get; set; }

        [AllowHtml]
        [Display(Name = "RemarkFr", ResourceType = typeof(StaticResource.Resources))]
        public string RemarkFr { get; set; }

        [AllowHtml]
        [Display(Name = "RemarkZh", ResourceType = typeof(StaticResource.Resources))]
        public string RemarkZh { get; set; }
    }
}