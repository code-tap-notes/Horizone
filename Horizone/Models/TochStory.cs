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

        [Display(Name = "Name", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MaxLength500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Content")]
        public string Content { get; set; }
        
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }
}