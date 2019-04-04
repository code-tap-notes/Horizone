using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class DescriptionManuscript
    {
        public int Id { get; set; }
       
        [AllowHtml]
        [Display(Name = "DescriptionEn", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionEn { get; set; }

        [AllowHtml]
        [Display(Name = "DescriptionFr", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionFr { get; set; }

        [AllowHtml]
        [Display(Name = "DescriptionZh", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionZh { get; set; }
    }
}