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

        [Display(Name = "NamePlaceEn", ResourceType = typeof(StaticResource.Resources))]
        public string PlaceEn { get; set; }

        [Display(Name = "NamePlaceFr", ResourceType = typeof(StaticResource.Resources))]
        public string PlaceFr { get; set; }

        [Display(Name = "NamePlaceZh", ResourceType = typeof(StaticResource.Resources))]
        public string PlaceZh { get; set; }

    }
}