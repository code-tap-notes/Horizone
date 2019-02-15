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
    public enum WordClass : byte
    {
        [EnumMember(Value = "Noun")]
        Noun,

        [EnumMember(Value = "Adjective")]
        Adjective,

        [EnumMember(Value = "Indeclinable")]
        Indeclinable,
        [EnumMember(Value = "Finite verb form")]
        FiniteVerbForme
    }
    public enum SubClass : byte
    {
        [EnumMember(Value = "Gerundive")]
        Gerundive,

        [EnumMember(Value = "Personal name")]
        PersonalName,

        [EnumMember(Value = "Unknown")]
        Unknown,
        [EnumMember(Value = "Verbal abstract")]
        VerbalAbstract,
        [EnumMember(Value = "Infinitive")]
        Infinitive,
        [EnumMember(Value = "Abstract")]
        Abstract,
    
        [EnumMember(Value = "Indeclinable adjective")]
        IndeclinableAdjective,

        [EnumMember(Value = "Privative")]
        Privative,

        [EnumMember(Value = "m-participle")]
        MParticiple,
        [EnumMember(Value = "nt-participle")]
        NtParticiple,
        
        [EnumMember(Value = "Adverb")]
        Adverb,
        [EnumMember(Value = "Verb plus pronoun suffix")]
        VerbPlusPronounSuffix
    }
    public enum Number : byte
    {
        [EnumMember(Value = "Singular")]
        Singular,
        [EnumMember(Value = "Dual")]
        Dual,

        [EnumMember(Value = "Plural")]
        Plural        
    }
    public enum Gender : byte
    {
        [EnumMember(Value = "Masculine")]
        Masculine,

        [EnumMember(Value = "Feminine")]
        Feminine,
        [EnumMember(Value = "Neuter")]
        Neuter

    }

    public class DictionaryTocharian
    {
        public int Id { get; set; }

        [Display(Name = "Words", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Word { get; set; }

        [Display(Name = "English", ResourceType = typeof(StaticResource.Resources))]
        public string English { get; set; }

        [Display(Name = "Francaise", ResourceType = typeof(StaticResource.Resources))]
        public string Francaise { get; set; }

        [Display(Name = "Chinese", ResourceType = typeof(StaticResource.Resources))]
        public string Chinese { get; set; }
        
        [EnumDataType(typeof(WordClass))]
        [JsonConverter(typeof(StringEnumConverter))]
        [Display(Name = "WordClass", ResourceType = typeof(StaticResource.Resources))]               
        public WordClass ClassOfWord  { get; set; }

        [Display(Name = "WordSubClass", ResourceType = typeof(StaticResource.Resources))]
        [EnumDataType(typeof(SubClass))]
        [JsonConverter(typeof(StringEnumConverter))]
        public SubClass WordSubClass  { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public string Language { get; set; }

        [Display(Name = "EquivalentInTA", ResourceType = typeof(StaticResource.Resources))]
        public string EquivalentInTA { get; set; }

        [Display(Name = "EquivalentInOther", ResourceType = typeof(StaticResource.Resources))]
        public string EquivalentInOther { get; set; }

        [Display(Name = "DerivedFrom", ResourceType = typeof(StaticResource.Resources))]
        public string DerivedFrom { get; set; }

        [Display(Name = "RelatedLexemes", ResourceType = typeof(StaticResource.Resources))]
        public string RelatedLexemes { get; set; }

        [Display(Name = "RootCharacter", ResourceType = typeof(StaticResource.Resources))]
        public string RootCharacter { get; set; }

        [Display(Name = "InternalRootRowel", ResourceType = typeof(StaticResource.Resources))]
        public string InternalRootVowel { get; set; }

        [Display(Name = "Paradigm", ResourceType = typeof(StaticResource.Resources))]
        public string Paradigm  { get; set; }

        [Display(Name = "Case", ResourceType = typeof(StaticResource.Resources))]
        public string Case  { get; set; }

        [EnumDataType(typeof(Number))]
        [JsonConverter(typeof(StringEnumConverter))]
        [Display(Name = "Number", ResourceType = typeof(StaticResource.Resources))]
        public Number WordNumber { get; set; }

        [EnumDataType(typeof(Gender))]
        [JsonConverter(typeof(StringEnumConverter))]
        [Display(Name = "Gender", ResourceType = typeof(StaticResource.Resources))]
        public Gender WordGender { get; set; }

        [Display(Name = "Stem", ResourceType = typeof(StaticResource.Resources))]
        public string Stem { get; set; }

        [Display(Name = "StemClass", ResourceType = typeof(StaticResource.Resources))]
        public string StemClass { get; set; }

        [Display(Name = "Voice", ResourceType = typeof(StaticResource.Resources))]
        public string Voice { get; set; }

        [Display(Name = "Nominate", ResourceType = typeof(StaticResource.Resources))]
        public string Nominate { get; set; }

        [Display(Name = "Oblique", ResourceType = typeof(StaticResource.Resources))]
        public string Oblique { get; set; }

        [Display(Name = "Vocative", ResourceType = typeof(StaticResource.Resources))]
        public string Vocative { get; set; }

        [Display(Name = "Genitive", ResourceType = typeof(StaticResource.Resources))]
        public string Genitive { get; set; }

        [Display(Name = "Locative", ResourceType = typeof(StaticResource.Resources))]
        public string Locative { get; set; }

        [Display(Name = "Ablative", ResourceType = typeof(StaticResource.Resources))]
        public string Ablative { get; set; }

        [Display(Name = " Allative", ResourceType = typeof(StaticResource.Resources))]
        public string Allative { get; set; }

        [Display(Name = "Perlative", ResourceType = typeof(StaticResource.Resources))]
        public string Perlative { get; set; }

        [Display(Name = "Instrumental", ResourceType = typeof(StaticResource.Resources))]
        public string Instrumental { get; set; }

        [Display(Name = "Comitative", ResourceType = typeof(StaticResource.Resources))]
        public string Comitative { get; set; }

        [Display(Name = "Causative", ResourceType = typeof(StaticResource.Resources))]
        public string Causative { get; set; }
  
        [AllowHtml]
        [Display(Name = "Conjugation", ResourceType = typeof(StaticResource.Resources))]
        public string Conjugation { get; set; }

        [Display(Name = "Picture", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<ImageDictionary> ImageDictionarys { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }
    }

}