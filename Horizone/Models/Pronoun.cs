using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Pronoun
    {
        public int Id { get; set; }

        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public int DictionaryId { get; set; }

        [ForeignKey("DictionaryId")]
        public DictionaryTocharian DictionaryTocharian { get; set; }

        [Display(Name = "Case", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Case> Cases { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Gender> Genders { get; set; }

        [Display(Name = "Person", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Person> Persons { get; set; }
    }
}