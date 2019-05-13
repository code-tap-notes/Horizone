using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class ProperNoun
    {
        public int Id { get; set; }

        [Display(Name = "ProperNoun", ResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }

        [Display(Name = "TochStory", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<TochStory> TochStories { get; set; }

    }
}