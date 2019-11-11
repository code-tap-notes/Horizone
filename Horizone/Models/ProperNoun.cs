using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ProperNoun
    {
        public int Id { get; set; }

        [Display(Name = "ProperNoun", ResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionEn { get; set; }
        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionFr { get; set; }
        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionZh { get; set; }

        [Display(Name = "TochStory", ResourceType = typeof(StaticResource.Resources))]
        public Boolean InStory { get; set; }


    }
}