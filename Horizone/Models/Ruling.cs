using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Ruling
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "RulingEn", ResourceType = typeof(StaticResource.Resources))]
        public string RulingEn { get; set; }

        [AllowHtml]
        [Display(Name = "RulingFr", ResourceType = typeof(StaticResource.Resources))]
        public string RulingFr { get; set; }

        [AllowHtml]
        [Display(Name = "RulingZh", ResourceType = typeof(StaticResource.Resources))]
        public string RulingZh { get; set; }
    }
}