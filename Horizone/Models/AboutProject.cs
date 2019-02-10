using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class AboutProject
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "DateModifier", ResourceType = typeof(StaticResource.Resources))]
        public DateTime DateModifier
        {
            get
            {
                return DateTime.Now;
            }
        }
        [AllowHtml]
        [Display(Name = "Aim", ResourceType = typeof(StaticResource.Resources))]
        public string Aim { get; set; }

        [AllowHtml]
        [Display(Name = "Funding", ResourceType = typeof(StaticResource.Resources))]
        public string Funding { get; set; }

        [AllowHtml]
        [Display(Name = "Programing", ResourceType = typeof(StaticResource.Resources))]
        public string Programing { get; set; }

        [AllowHtml]
        [Display(Name = "Feedback", ResourceType = typeof(StaticResource.Resources))]
        public string Feedback { get; set; }

        
        [AllowHtml]
        [Display(Name = "Contact", ResourceType = typeof(StaticResource.Resources))]
        public string Contact { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }
}