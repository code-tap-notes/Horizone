using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Display(Name = "Abbreviations", ResourceType = typeof(StaticResource.Resources))]
        public string ConjugatedPerson { get; set; }

        [Display(Name = "PersonEn", ResourceType = typeof(StaticResource.Resources))]
        public string ConjugatedPersonEn { get; set; }

        [Display(Name = "PersonFr", ResourceType = typeof(StaticResource.Resources))]
        public string ConjugatedPersonFr { get; set; }

        [Display(Name = "PersonZh", ResourceType = typeof(StaticResource.Resources))]
        public string ConjugatedPersonZh { get; set; }

        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<DictionaryTocharian> DictionaryTocharians { get; set; }
    }
}