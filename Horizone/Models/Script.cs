using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Script
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "ScriptEn", ResourceType = typeof(StaticResource.Resources))]
        public string ScriptEn { get; set; }

        [AllowHtml]
        [Display(Name = "ScriptFr", ResourceType = typeof(StaticResource.Resources))]
        public string ScriptFr { get; set; }

        [AllowHtml]
        [Display(Name = "ScriptZh", ResourceType = typeof(StaticResource.Resources))]
        public string ScriptZh { get; set; }
    }
}