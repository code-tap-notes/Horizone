using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Horizone.Models
{
    public class SourceStory
    {
        public int Id { get; set; }

        [Display(Name = "SourceStory", ResourceType = typeof(StaticResource.Resources))]
        public string SourceEn { get; set; }

        [Display(Name = "SourceStory", ResourceType = typeof(StaticResource.Resources))]
        public string SourceFr { get; set; }

        [Display(Name = "SourceStory", ResourceType = typeof(StaticResource.Resources))]
        public string SourceZh { get; set; }
    }
}