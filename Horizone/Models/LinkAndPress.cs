using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class LinkAndPress
    {
        public int Id { get; set; }
        [Display(Name = "TitleArticle", ResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }
        
        [Display(Name = "Link", ResourceType = typeof(StaticResource.Resources))]
        public string Link { get; set; }

        [Display(Name = "OrderOfLink", ResourceType = typeof(StaticResource.Resources))]
        public int Order { get; set; }

        [Display(Name = "Press", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Press { get; set; }

        public Byte Status { get; set; }
        [Display(Name = "ListedPosition", ResourceType = typeof(StaticResource.Resources))]
        public string Target { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }
}