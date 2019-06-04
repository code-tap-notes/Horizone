using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Mood
    {
        public int Id { get; set; }

        [Display(Name = "Abbreviations", ResourceType = typeof(StaticResource.Resources))]
        public string AbbreviationsMood { get; set; }

        [Display(Name = "Mood", ResourceType = typeof(StaticResource.Resources))]
        public string MoodEn { get; set; }

        [Display(Name = "Mood", ResourceType = typeof(StaticResource.Resources))]
        public string MoodFr { get; set; }

        [Display(Name = "Mood", ResourceType = typeof(StaticResource.Resources))]
        public string MoodZh { get; set; }
    }
}