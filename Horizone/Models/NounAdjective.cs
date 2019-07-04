using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class NounAdjective : Word
    {
        [Display(Name = "Case", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Case> Cases { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Gender> Genders { get; set; }

    }
}