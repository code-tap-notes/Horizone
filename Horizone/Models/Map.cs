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

        [Display(Name = "NamePicture", ResourceType = typeof(StaticResource.Resources))]
        public string NamePicture { get; set; }
       
        [Display(Name = "Picture", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<ImageMap> ImageMaps { get; set; }
      
    }
}