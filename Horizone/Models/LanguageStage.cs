using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class LanguageStage
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "LanguageStageEn", ResourceType = typeof(StaticResource.Resources))]
        public string LanguageStageEn { get; set; }

        [AllowHtml]
        [Display(Name = "LanguageStageFr", ResourceType = typeof(StaticResource.Resources))]
        public string LanguageStageFr { get; set; }

        [AllowHtml]
        [Display(Name = "LanguageStageZh", ResourceType = typeof(StaticResource.Resources))]
        public string LanguageStageZh { get; set; }
    }
}