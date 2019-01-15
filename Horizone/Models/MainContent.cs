using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Runtime.Serialization;

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
        [StringLength(1500, MinimumLength = 1, ErrorMessageResourceName = "MaxLength1500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string AboutUs { get; set; }

        [AllowHtml]
        [Display(Name = "Contact", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(1500, MinimumLength = 1, ErrorMessageResourceName = "MaxLength1500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Contact { get; set; }

        [AllowHtml]
        [Display(Name = "Presentation", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(1500, MinimumLength = 1, ErrorMessageResourceName = "MaxLength1500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Presentation { get; set; }


        [Display(Name = "Picture", ResourceType = typeof(StaticResource.Resources))]
        public string Picture { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }
    
}