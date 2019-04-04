using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class SubGenderManuscript
    {
        public int Id { get; set; }

        [Display(Name = "SubGenderEn", ResourceType = typeof(StaticResource.Resources))]
        public string SubGenderEn { get; set; }

        [Display(Name = "SubGenderFr", ResourceType = typeof(StaticResource.Resources))]
        public string NameGenderFr { get; set; }

        [Display(Name = "SubGenderZh", ResourceType = typeof(StaticResource.Resources))]
        public string NameGenderZh { get; set; }
     
    }
}