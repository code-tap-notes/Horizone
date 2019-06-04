using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Voice
    {
        public int Id { get; set; }

        [Display(Name = "Voice", ResourceType = typeof(StaticResource.Resources))]
        public string AbbreviationVoice { get; set; }

        [Display(Name = "VoiceFr", ResourceType = typeof(StaticResource.Resources))]
        public string VoiceEn { get; set; }

        [Display(Name = "VoiceFr", ResourceType = typeof(StaticResource.Resources))]
        public string VoiceFr { get; set; }

        [Display(Name = "VoiceZh", ResourceType = typeof(StaticResource.Resources))]
        public string VoiceZh { get; set; }

    }
}