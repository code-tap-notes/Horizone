using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class RulingColor
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "RulingColorEn", ResourceType = typeof(StaticResource.Resources))]
        public string RulingColorEn { get; set; }

        [AllowHtml]
        [Display(Name = "RulingColorFr", ResourceType = typeof(StaticResource.Resources))]
        public string RulingColorFr { get; set; }

        [AllowHtml]
        [Display(Name = "RulingColorZh", ResourceType = typeof(StaticResource.Resources))]
        public string RulingColorZh { get; set; }
    }
}