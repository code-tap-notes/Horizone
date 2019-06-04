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

        [Display(Name = "Words", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Word { get; set; }

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

        [Display(Name = "EquivalentInOther", ResourceType = typeof(StaticResource.Resources))]
        public string EquivalentInOther { get; set; }

        [Display(Name = "DerivedFrom", ResourceType = typeof(StaticResource.Resources))]
        public string DerivedFrom { get; set; }

        [Display(Name = "RelatedLexemes", ResourceType = typeof(StaticResource.Resources))]
        public string RelatedLexemes { get; set; }

        [Display(Name = "RootCharacter", ResourceType = typeof(StaticResource.Resources))]
        public string RootCharacter { get; set; }

        [Display(Name = "InternalRootVowel", ResourceType = typeof(StaticResource.Resources))]
        public string InternalRootVowel { get; set; }

        [Display(Name = "Case", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Case> Cases { get; set; }
     
        [Display(Name = "Number", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Number> Numbers { get; set; }
       
        [Display(Name = "Gender", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Gender> Genders { get; set; }
       
        [Display(Name = "Person", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Person> Persons { get; set; }
   
        //InflectionalParadigm

        [Display(Name = "NominateMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string NominateMasculineSingular { get; set; }

        [Display(Name = "NominateMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string NominateMasculineDual { get; set; }

        [Display(Name = "NominateMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string NominateMasculinePlural { get; set; }

        [Display(Name = "NominateFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string NominateFeminineSingular { get; set; }

        [Display(Name = "NominateFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string NominateFeminineDual { get; set; }

        [Display(Name = "NominateFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string NominateFemininePlural { get; set; }

        [Display(Name = "NominateNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string NominateNeuterSingular { get; set; }

        [Display(Name = "NominateNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string NominateNeuterDual { get; set; }

        [Display(Name = "NominateNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string NominateNeuterPlural { get; set; }

        [Display(Name = "ObliqueMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueMasculineSingular { get; set; }

        [Display(Name = "ObliqueMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueMasculineDual { get; set; }

        [Display(Name = "ObliqueMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueMasculinePlural { get; set; }

        [Display(Name = "ObliqueFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueFeminineSingular { get; set; }

        [Display(Name = "ObliqueFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueFeminineDual { get; set; }

        [Display(Name = "ObliqueFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueFemininePlural { get; set; }

        [Display(Name = "ObliqueNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueNeuterSingular { get; set; }

        [Display(Name = "ObliqueNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueNeuterDual { get; set; }

        [Display(Name = "ObliqueNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string ObliqueNeuterPlural { get; set; }

        [Display(Name = "VocativeMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeMasculineSingular { get; set; }

        [Display(Name = "VocativeMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeMasculineDual { get; set; }

        [Display(Name = "VocativeMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeMasculinePlural { get; set; }

        [Display(Name = "VocativeFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeFeminineSingular { get; set; }

        [Display(Name = "VocativeFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeFeminineDual { get; set; }

        [Display(Name = "VocativeFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeFemininePlural { get; set; }

        [Display(Name = "VocativeNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeNeuterSingular { get; set; }

        [Display(Name = "VocativeNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeNeuterDual { get; set; }

        [Display(Name = "VocativeNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string VocativeNeuterPlural { get; set; }

        [Display(Name = "GenitiveMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveMasculineSingular { get; set; }

        [Display(Name = "GenitiveMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveMasculineDual { get; set; }

        [Display(Name = "GenitiveMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveMasculinePlural { get; set; }

        [Display(Name = "GenitiveFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveFeminineSingular { get; set; }

        [Display(Name = "GenitiveFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveFeminineDual { get; set; }

        [Display(Name = "GenitiveFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveFemininePlural { get; set; }

        [Display(Name = "GenitiveNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveNeuterSingular { get; set; }

        [Display(Name = "GenitiveNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveNeuterDual { get; set; }

        [Display(Name = "GenitiveNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string GenitiveNeuterPlural { get; set; }

        [Display(Name = "LocativeMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeMasculineSingular { get; set; }

        [Display(Name = "LocativeMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeMasculineDual { get; set; }

        [Display(Name = "LocativeMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeMasculinePlural { get; set; }

        [Display(Name = "LocativeFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeFeminineSingular { get; set; }

        [Display(Name = "LocativeFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeFeminineDual { get; set; }

        [Display(Name = "LocativeFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeFemininePlural { get; set; }

        [Display(Name = "LocativeNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeNeuterSingular { get; set; }

        [Display(Name = "LocativeNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeNeuterDual { get; set; }

        [Display(Name = "LocativeNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string LocativeNeuterPlural { get; set; }

        [Display(Name = "AblativeMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeMasculineSingular { get; set; }

        [Display(Name = "AblativeMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeMasculineDual { get; set; }

        [Display(Name = "AblativeMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeMasculinePlural { get; set; }

        [Display(Name = "AblativeFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeFeminineSingular { get; set; }

        [Display(Name = "AblativeFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeFeminineDual { get; set; }

        [Display(Name = "AblativeFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeFemininePlural { get; set; }

        [Display(Name = "AblativeNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeNeuterSingular { get; set; }

        [Display(Name = "AblativeNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeNeuterDual { get; set; }

        [Display(Name = "AblativeNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string AblativeNeuterPlural { get; set; }

        [Display(Name = "AllativeMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeMasculineSingular { get; set; }

        [Display(Name = "AllativeMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeMasculineDual { get; set; }

        [Display(Name = "AllativeMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeMasculinePlural { get; set; }

        [Display(Name = "AllativeFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeFeminineSingular { get; set; }

        [Display(Name = "AllativeFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeFeminineDual { get; set; }

        [Display(Name = "AllativeFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeFemininePlural { get; set; }

        [Display(Name = "AllativeNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeNeuterSingular { get; set; }

        [Display(Name = "AllativeNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeNeuterDual { get; set; }

        [Display(Name = "AllativeNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string AllativeNeuterPlural { get; set; }

        [Display(Name = "PerlativeMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeMasculineSingular { get; set; }

        [Display(Name = "PerlativeMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeMasculineDual { get; set; }

        [Display(Name = "PerlativeMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeMasculinePlural { get; set; }

        [Display(Name = "PerlativeFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeFeminineSingular { get; set; }

        [Display(Name = "PerlativeFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeFeminineDual { get; set; }

        [Display(Name = "PerlativeFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeFemininePlural { get; set; }

        [Display(Name = "PerlativeNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeNeuterSingular { get; set; }

        [Display(Name = "PerlativeNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeNeuterDual { get; set; }

        [Display(Name = "PerlativeNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string PerlativeNeuterPlural { get; set; }

        [Display(Name = "InstrumentalMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalMasculineSingular { get; set; }

        [Display(Name = "InstrumentalMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalMasculineDual { get; set; }

        [Display(Name = "InstrumentalMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalMasculinePlural { get; set; }

        [Display(Name = "InstrumentalFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalFeminineSingular { get; set; }

        [Display(Name = "InstrumentalFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalFeminineDual { get; set; }

        [Display(Name = "InstrumentalFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalFemininePlural { get; set; }

        [Display(Name = "InstrumentalNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalNeuterSingular { get; set; }

        [Display(Name = "InstrumentalFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalNeuterDual { get; set; }

        [Display(Name = "InstrumentalNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string InstrumentalNeuterPlural { get; set; }

        [Display(Name = "ComitativeMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeMasculineSingular { get; set; }

        [Display(Name = "ComitativeMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeMasculineDual { get; set; }

        [Display(Name = "ComitativeMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeMasculinePlural { get; set; }

        [Display(Name = "ComitativeFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeFeminineSingular { get; set; }

        [Display(Name = "ComitativeFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeFeminineDual { get; set; }

        [Display(Name = "ComitativeFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeFemininePlural { get; set; }

        [Display(Name = "ComitativeNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeNeuterSingular { get; set; }

        [Display(Name = "ComitativeNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeNeuterDual { get; set; }

        [Display(Name = "ComitativeNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string ComitativeNeuterPlural { get; set; }

        [Display(Name = "CausativeMasculineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeMasculineSingular { get; set; }

        [Display(Name = "CausativeMasculineDual", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeMasculineDual { get; set; }

        [Display(Name = "CausativeMasculinePlural", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeMasculinePlural { get; set; }

        [Display(Name = "CausativeFeminineSingular", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeFeminineSingular { get; set; }

        [Display(Name = "CausativeFeminineDual", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeFeminineDual { get; set; }

        [Display(Name = "CausativeFemininePlural", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeFemininePlural { get; set; }

        [Display(Name = "CausativeNeuterSingular", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeNeuterSingular { get; set; }

        [Display(Name = "CausativeNeuterDual", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeNeuterDual { get; set; }

        [Display(Name = "CausativeNeuterPlural", ResourceType = typeof(StaticResource.Resources))]
        public string CausativeNeuterPlural { get; set; }
        //Verb and adj
        [Display(Name = "Stem", ResourceType = typeof(StaticResource.Resources))]
        public string Stem { get; set; }

        [Display(Name = "StemClass", ResourceType = typeof(StaticResource.Resources))]
        public string StemClass { get; set; }

        [Display(Name = "Voice", ResourceType = typeof(StaticResource.Resources))]
        public int VoiceId { get; set; }

        [ForeignKey("VoiceId")]
        public Voice Voice { get; set; }

        [Display(Name = "Valency", ResourceType = typeof(StaticResource.Resources))]
        public int ValencyId { get; set; }

        [ForeignKey("ValencyId")]
        public Valency Valency { get; set; }

        [Display(Name = "TenseAndAspect", ResourceType = typeof(StaticResource.Resources))]
        public int TenseAndAspectId { get; set; }

        [ForeignKey("TenseAndAspectId")]
        public TenseAndAspect TenseAndAspect { get; set; }

        [Display(Name = "Mood", ResourceType = typeof(StaticResource.Resources))]
        public int MoodId { get; set; }

        [ForeignKey("MoodId")]
        public Mood Mood { get; set; }

        [AllowHtml]
        [Display(Name = "PronounSuffix", ResourceType = typeof(StaticResource.Resources))]
        public string PronounSuffix { get; set; }
              
        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }
      
    }

}