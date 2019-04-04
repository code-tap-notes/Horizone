using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ScriptAdd
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "ScriptAddEn", ResourceType = typeof(StaticResource.Resources))]
        public string ScriptAddEn { get; set; }

        [AllowHtml]
        [Display(Name = "ScriptAddFr", ResourceType = typeof(StaticResource.Resources))]
        public string ScriptAddFr { get; set; }

        [AllowHtml]
        [Display(Name = "ScriptAddZh", ResourceType = typeof(StaticResource.Resources))]
        public string ScriptAddZh { get; set; }

    }
}