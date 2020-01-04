using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class OtherWord
    {
        public int Id { get; set; }
        [Display(Name = "DictionaryTocharian", ResourceType = typeof(StaticResource.Resources))]
        public int DictionaryId { get; set; }

        [ForeignKey("DictionaryId")]
        public DictionaryTocharian DictionaryTocharian { get; set; }

    }
}