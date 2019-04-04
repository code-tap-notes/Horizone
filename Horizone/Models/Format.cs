using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Format
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "FormatEn", ResourceType = typeof(StaticResource.Resources))]
        public string FormatEn { get; set; }

        [AllowHtml]
        [Display(Name = "FormatFr", ResourceType = typeof(StaticResource.Resources))]
        public string FormatFr { get; set; }

        [AllowHtml]
        [Display(Name = "FormatZh", ResourceType = typeof(StaticResource.Resources))]
        public string FormatZh { get; set; }
    }
}