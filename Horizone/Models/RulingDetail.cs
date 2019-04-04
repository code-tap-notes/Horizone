using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class RulingDetail
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "RulingDetailEn", ResourceType = typeof(StaticResource.Resources))]
        public string RulingDetailEn { get; set; }

        [AllowHtml]
        [Display(Name = "RulingDetailFr", ResourceType = typeof(StaticResource.Resources))]
        public string RulingDetailFr { get; set; }

        [AllowHtml]
        [Display(Name = "RulingDetailZh", ResourceType = typeof(StaticResource.Resources))]
        public string RulingDetailZh { get; set; }
    }
}