using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class PaperColor
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "PaperColorEn", ResourceType = typeof(StaticResource.Resources))]
        public string PaperColorEn { get; set; }

        [AllowHtml]
        [Display(Name = "PaperColorFr", ResourceType = typeof(StaticResource.Resources))]
        public string PaperColorFr { get; set; }

        [AllowHtml]
        [Display(Name = "PaperColorZh", ResourceType = typeof(StaticResource.Resources))]
        public string PaperColorZh { get; set; }
    }
}