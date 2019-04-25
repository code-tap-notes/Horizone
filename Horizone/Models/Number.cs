using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Number
    {
        public int Id { get; set; }

        [Display(Name = "Abbreviations", ResourceType = typeof(StaticResource.Resources))]
        public string WordNumber { get; set; }


        [Display(Name = "NumberEn", ResourceType = typeof(StaticResource.Resources))]
        public string WordNumberEn { get; set; }

        [Display(Name = "NumberFr", ResourceType = typeof(StaticResource.Resources))]
        public string WordNumberFr { get; set; }

        [Display(Name = "NumberEn", ResourceType = typeof(StaticResource.Resources))]
        public string WordNumberZh { get; set; }

        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<DictionaryTocharian> DictionaryTocharians { get; set; }
    }
}