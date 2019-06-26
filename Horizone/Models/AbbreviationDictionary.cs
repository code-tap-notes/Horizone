using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class AbbreviationDictionary
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "Symbol", ResourceType = typeof(StaticResource.Resources))]
        public string Symbol { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [Display(Name = "OtherAbbreviation", ResourceType = typeof(StaticResource.Resources))]
        public Boolean OtherAbbreviation { get; set; }

        [Display(Name = "Manuscript", ResourceType = typeof(StaticResource.Resources))]
        public Boolean AbbreviationManuscript { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public Boolean AbbreviationsLanguage { get; set; }

        [Display(Name = "GrammaticalAbbreviation", ResourceType = typeof(StaticResource.Resources))]
        public Boolean GrammaticalAbbreviation { get; set; }

    }
}