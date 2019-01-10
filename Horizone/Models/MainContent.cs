using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace Horizone.Models
{
    public class MainContent
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DateModifier",ResourceType =typeof(StaticResource.Resources))]
        public DateTime DateModifier
        {
            get
            {
                return DateTime.Now;
            }
        }
        [AllowHtml]
        [Display(Name = "AboutUs", ResourceType = typeof(StaticResource.Resources))]        
        [StringLength(1500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string AboutUs { get; set; }

        [AllowHtml]
        [Display(Name = "Contact", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(1500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Contact { get; set; }

        [AllowHtml]
        [Display(Name = "Presentation", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(1500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Presentation { get; set; }
        
    }
}