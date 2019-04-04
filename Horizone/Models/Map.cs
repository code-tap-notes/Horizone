using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Map
    {
        public int Id { get; set; }
        
        [AllowHtml]
        [Display(Name = "MainFindSpot", ResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }
      
        [Display(Name = "Maps", ResourceType = typeof(StaticResource.Resources))]
        public String UlrMap { get; set; }
      
    }
}