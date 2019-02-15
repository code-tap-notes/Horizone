using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class TochPhrase
    {
        public int Id { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Phrase", ResourceType = typeof(StaticResource.Resources))]
        public string Phrase { get; set; }

        [AllowHtml]
        [Display(Name = "English", ResourceType = typeof(StaticResource.Resources))]
        public string English { get; set; }

        [AllowHtml]
        [Display(Name = "Francaise", ResourceType = typeof(StaticResource.Resources))]
        public string Francaise { get; set; }

        [AllowHtml]
        [Display(Name = "Chinese", ResourceType = typeof(StaticResource.Resources))]
        public string Chinese { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public string Language { get; set; }

        [Display(Name = "DerivedFrom", ResourceType = typeof(StaticResource.Resources))]
        public string DerivedFrom { get; set; }

        [Display(Name = "RelatedLexemes", ResourceType = typeof(StaticResource.Resources))]
        public string RelatedLexemes { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }

    }
}