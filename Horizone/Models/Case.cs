using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Case
    {
        public int Id { get; set; }

        [Display(Name = "Abbreviations", ResourceType = typeof(StaticResource.Resources))]
        public string NameCase { get; set; }
        
        [Display(Name = "CaseEn", ResourceType = typeof(StaticResource.Resources))]
        public string NameCaseEn { get; set; }

        [Display(Name = "CaseFr", ResourceType = typeof(StaticResource.Resources))]
        public string NameCaseFr { get; set; }

        [Display(Name = "CaseZh", ResourceType = typeof(StaticResource.Resources))]
        public string NameCaseZh { get; set; }

        [Display(Name = "Word", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<DictionaryTocharian> DictionaryTocharians { get; set; }
        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<NounAdjective> NounAdjectives { get; set; }
        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Pronoun> Pronouns { get; set; }

    }
}