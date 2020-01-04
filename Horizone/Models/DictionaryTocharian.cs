using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Horizone.Models
{
     
    public class DictionaryTocharian
    {
        //Common
        public int Id { get; set; }

        [Display(Name = "Tocharian", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Word { get; set; }

        [Display(Name = "Sanskrit", ResourceType = typeof(StaticResource.Resources))]
        public string Sanskrit { get; set; }

        [Display(Name = "English", ResourceType = typeof(StaticResource.Resources))]
        public string English { get; set; }

        [Display(Name = "French", ResourceType = typeof(StaticResource.Resources))]
        public string Francaise { get; set; }

        [Display(Name = "German", ResourceType = typeof(StaticResource.Resources))]
        public string German { get; set; }

        [Display(Name = "Latin", ResourceType = typeof(StaticResource.Resources))]
        public string Latin { get; set; }

        [Display(Name = "Chinese", ResourceType = typeof(StaticResource.Resources))]
        public string Chinese { get; set; }

        [Display(Name = "WordClass", ResourceType = typeof(StaticResource.Resources))]
        public int WordClassId { get; set; }

        [ForeignKey("WordClassId")]
        public WordClass WordClass { get; set; }
        
        [Display(Name = "WordSubClass", ResourceType = typeof(StaticResource.Resources))]
        public int WordSubClassId { get; set; }

        [ForeignKey("WordSubClassId")]
        public WordSubClass WordSubClass { get; set; }

        [Display(Name = "TochLanguage", ResourceType = typeof(StaticResource.Resources))]
        public int TochLanguageId { get; set; }

        [ForeignKey("TochLanguageId")]
        public TochLanguage TochLanguage { get; set; }

        [Display(Name = "EquivalentTocharianA", ResourceType = typeof(StaticResource.Resources))]
        public string EquivalentTA { get; set; }

        [Display(Name = "EquivalentTocharianB", ResourceType = typeof(StaticResource.Resources))]
        public string EquivalentTB { get; set; }

        [Display(Name = "TochCommon", ResourceType = typeof(StaticResource.Resources))]
        public string TochCommon { get; set; }

        [Display(Name = "TochCorrespondence", ResourceType = typeof(StaticResource.Resources))]
        public string TochCorrespondence { get; set; }

        [Display(Name = "EquivalentInOther", ResourceType = typeof(StaticResource.Resources))]
        public string EquivalentInOther { get; set; }
              
        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "IndexSource", ResourceType = typeof(StaticResource.Resources))]
        public int IdClassSource { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }
      
    }

}