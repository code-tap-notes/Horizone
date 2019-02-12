using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class InThePresse
    {
        public int Id { get; set; }

        [Display(Name = "TitleArticle", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = " Link", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(200, MinimumLength = 1, ErrorMessageResourceName = "MaxLength500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string LinkThePresse { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }

    }
}