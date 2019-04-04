using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Material
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "MaterialEn", ResourceType = typeof(StaticResource.Resources))]
        public string MaterialEn { get; set; }

        [AllowHtml]
        [Display(Name = "MaterialFr", ResourceType = typeof(StaticResource.Resources))]
        public string MaterialFr { get; set; }

        [AllowHtml]
        [Display(Name = "MaterialZh", ResourceType = typeof(StaticResource.Resources))]
        public string MaterialZh { get; set; }
    }
}