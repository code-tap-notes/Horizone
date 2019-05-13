using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "ScriptType", ResourceType = typeof(StaticResource.Resources))]
        public int ScriptTypeId { get; set; }

        [ForeignKey("ScriptTypeId")]
        public ScriptType ScriptType { get; set; }
    }
}