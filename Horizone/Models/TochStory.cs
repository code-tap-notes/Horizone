using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class TochStory
    {
        public int Id { get; set; }

        [Display(Name = "NameStory", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MaxLength500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }

        [Display(Name = "SourceStory", ResourceType = typeof(StaticResource.Resources))]
        public int SourceStoryId { get; set; }

        [ForeignKey("SourceStoryId")]
        public SourceStory SourceStory { get; set; }

        [Display(Name = "ThemeStory", ResourceType = typeof(StaticResource.Resources))]
        public int ThemeStoryId { get; set; }

        [ForeignKey("ThemeStoryId")]
        public ThemeStory ThemeStory { get; set; }
    
        [Display(Name = "PlasticRepresentation", ResourceType = typeof(StaticResource.Resources))]
        public string PlasticRepresentation { get; set; }

        [Display(Name = "MainFindSpot", ResourceType = typeof(StaticResource.Resources))]
        public string MainFindSpot { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [AllowHtml]
        [Display(Name = "English", ResourceType = typeof(StaticResource.Resources))]
        public string English { get; set; }

        [AllowHtml]
        [Display(Name = "French", ResourceType = typeof(StaticResource.Resources))]
        public string Francaise { get; set; }

        [AllowHtml]
        [Display(Name = "Chinese", ResourceType = typeof(StaticResource.Resources))]
        public string Chinese { get; set; }
       
        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }
        
        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }
       
    }
}