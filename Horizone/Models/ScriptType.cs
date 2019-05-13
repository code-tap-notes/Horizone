using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ScriptType
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "ScriptType", ResourceType = typeof(StaticResource.Resources))]
        public string NameType { get; set; }        
    }
}