using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class LanguageDetail
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "LanguageDetailEn", ResourceType = typeof(StaticResource.Resources))]
        public string LanguageDetailEn { get; set; }

        [AllowHtml]
        [Display(Name = "LanguageDetailFr", ResourceType = typeof(StaticResource.Resources))]
        public string LanguageDetailFr { get; set; }

        [AllowHtml]
        [Display(Name = "LanguageDetailZh", ResourceType = typeof(StaticResource.Resources))]
        public string LanguageDetailZh { get; set; }
    }
}