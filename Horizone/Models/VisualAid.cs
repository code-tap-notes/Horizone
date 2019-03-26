using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class VisualAid
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Help", ResourceType = typeof(StaticResource.Resources))]
        public string Aids { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [Display(Name = "Photography", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Photography { get; set; }

        [Display(Name = "Maps", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Map { get; set; }
    }
}