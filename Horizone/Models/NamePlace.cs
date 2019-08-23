using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class NamePlace
    {
        public int Id { get; set; }

        [Display(Name = "NamePlaces", ResourceType = typeof(StaticResource.Resources))]
        public string Place { get; set; }

        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionEn { get; set; }

        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionFr { get; set; }

        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string DescriptionZh { get; set; }

    }
}