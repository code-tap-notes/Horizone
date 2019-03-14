using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class News
    {
        public int Id { get; set; }

        [Display(Name = "TitleArticle", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }

        [AllowHtml]
        [Display(Name = "Summary", ResourceType = typeof(StaticResource.Resources))]
        public string Summary { get; set; }

        [DataType(DataType.DateTime)]                             
        [Display(Name = "DateModifier",ResourceType = typeof(StaticResource.Resources))]        
        public DateTime Date {
            get {
                return DateTime.Now;
            }
          }
        [AllowHtml]
        [Display(Name = "Link",ResourceType = typeof(StaticResource.Resources))]
        public string Content{ get; set; }
       
        [Display(Name = "Views", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 10000, ErrorMessageResourceName = "Positive", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int View { get; set; }

        [Display(Name = "Topic", ResourceType = typeof(StaticResource.Resources))]
        public int TopicId { get; set; }

        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }

        [Display(Name = "PublishedBy", ResourceType = typeof(StaticResource.Resources))]
        public int CollaboratorId { get; set; }

        [ForeignKey("CollaboratorId")]
        public Collaborator Collaborator { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<ImageNews> ImageNewses { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }      
    }
}