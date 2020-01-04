using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class NamePlace
    {
        public int Id { get; set; }

        [Display(Name = "NamePlaces", ResourceType = typeof(StaticResource.Resources))]
        public string Place { get; set; }
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