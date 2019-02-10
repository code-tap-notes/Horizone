using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Publication
    {
        public int Id { get; set; }

        [Display(Name = "PublicationDate", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(10, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string PublicationDate { get; set; }

        [AllowHtml]
        [Display(Name = "TitleArticle", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Newspaper", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Journal { get; set; }

        [Display(Name = "Link", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string UlrBibliography { get; set; }
        
        [Display(Name = "Collaboration", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Collaboration> Collaborations { get; set; }
    }
}