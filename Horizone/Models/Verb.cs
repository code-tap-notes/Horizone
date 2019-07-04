using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Verb : Word
    {

        [Display(Name = "Voice", ResourceType = typeof(StaticResource.Resources))]
        public int VoiceId { get; set; }

        [ForeignKey("VoiceId")]
        public Voice Voice { get; set; }

        [Display(Name = "Valency", ResourceType = typeof(StaticResource.Resources))]
        public int ValencyId { get; set; }

        [ForeignKey("ValencyId")]
        public Valency Valency { get; set; }

        [Display(Name = "TenseAndAspect", ResourceType = typeof(StaticResource.Resources))]
        public int TenseAndAspectId { get; set; }

        [ForeignKey("TenseAndAspectId")]
        public TenseAndAspect TenseAndAspect { get; set; }

        [Display(Name = "Mood", ResourceType = typeof(StaticResource.Resources))]
        public int MoodId { get; set; }

        [ForeignKey("MoodId")]
        public Mood Mood { get; set; }

        [Display(Name = "Person", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Person> Persons { get; set; }

        [AllowHtml]
        [Display(Name = "PronounSuffix", ResourceType = typeof(StaticResource.Resources))]
        public string PronounSuffix { get; set; }

    }
}