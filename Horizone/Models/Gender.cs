using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Gender
    {
        public int Id { get; set; }

        [Display(Name = "Abbreviations", ResourceType = typeof(StaticResource.Resources))]
        public string NameGender { get; set; }

        [Display(Name = "GenderEn", ResourceType = typeof(StaticResource.Resources))]
        public string NameGenderEn { get; set; }

        [Display(Name = "GenderFr", ResourceType = typeof(StaticResource.Resources))]
        public string NameGenderFr { get; set; }

        [Display(Name = "GenderZh", ResourceType = typeof(StaticResource.Resources))]
        public string NameGenderZh { get; set; }

        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<DictionaryTocharian> DictionaryTocharians { get; set; }
    }
}