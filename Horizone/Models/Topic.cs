using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Topic
    {
        public int Id { get; set; }

        [Display(Name = "Sujet")]            
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]        
        public string NameFrench { get; set; }

        [Display(Name = "Topic")]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]             
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string NameEnglish { get; set; }

        [Display(Name = "话题")]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string TopicChinese { get; set; }

        [Display(Name = "Thể loại")]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string TopicVietnam { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public Language Language { get; set; }
    }
}