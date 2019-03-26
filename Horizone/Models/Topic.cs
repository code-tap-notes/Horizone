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

        [Display(Name = "TopicEn", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]             
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string TopicEn { get; set; }

        [Display(Name = "TopicFr", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string TopicFr { get; set; }

        [Display(Name = "TopicZh", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string TopicZh { get; set; }

        [Display(Name = "Activity", ResourceType = typeof(StaticResource.Resources))]
        public bool Activity { get; set; }

        [Display(Name = "News", ResourceType = typeof(StaticResource.Resources))]
        public bool News { get; set; }
    }
}