using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Manuscript
    {
        public int Id { get; set; }

        [Display(Name = "Catalogue", ResourceType = typeof(StaticResource.Resources))]
        public int CatalogieId { get; set; }

        [ForeignKey("CatalogieId")]
        public Catalogie Catalogie { get; set; }

        [Display(Name = "Index")]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Index { get; set; }

        //OverallDescription
        [Display(Name = "Collection", ResourceType = typeof(StaticResource.Resources))]
        public string Collection { get; set; }

        [Display(Name = "Siglum", ResourceType = typeof(StaticResource.Resources))]
        public string Siglum { get; set; }

        [Display(Name = "Joint", ResourceType = typeof(StaticResource.Resources))]
        public string Joint { get; set; }

        [Display(Name = "OtherSiglum", ResourceType = typeof(StaticResource.Resources))]
        public string OtherSiglum { get; set; }

        [Display(Name = "ExpeditionCode", ResourceType = typeof(StaticResource.Resources))]
        public string ExpeditionCode { get; set; }

        [Display(Name = "MainFindSpot", ResourceType = typeof(StaticResource.Resources))]
        public int MapId { get; set; }

        [ForeignKey("MapId")]
        public Map Map { get; set; }

        [Display(Name = "SpecificFindSpot", ResourceType = typeof(StaticResource.Resources))]
        public string SpecificFindSpot { get; set; }

        [Display(Name = "GeneralState", ResourceType = typeof(StaticResource.Resources))]      
        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]       
        public int DescriptionManuscriptId { get; set; }

        [ForeignKey("DescriptionManuscriptId")]
        public DescriptionManuscript DescriptionManuscript{ get; set; }

        [Display(Name = "Remark", ResourceType = typeof(StaticResource.Resources))]
        public int RemarkAddId { get; set; }

        [ForeignKey("RemarkAddId")]
        public RemarkAdd RemarkAdd { get; set; }

        [Display(Name = "LeafNumber", ResourceType = typeof(StaticResource.Resources))]
        public string LeafNumber { get; set; }
        //LayoutManuscript
        [Display(Name = "SizeHeight", ResourceType = typeof(StaticResource.Resources))]
        public string SizeHeight { get; set; }

        [Display(Name = "Completeness", ResourceType = typeof(StaticResource.Resources))]
        public string Completeness { get; set; }

        [Display(Name = "SizeWidth", ResourceType = typeof(StaticResource.Resources))]
        public string SizeWidth { get; set; }

        [Display(Name = "NumberOfLine", ResourceType = typeof(StaticResource.Resources))]
        public int NumberOfLine { get; set; }

        [Display(Name = "LineDistance", ResourceType = typeof(StaticResource.Resources))]
        public string LineDistance { get; set; }

        [Display(Name = "Format", ResourceType = typeof(StaticResource.Resources))]
        public int FormatId { get; set; }

        [ForeignKey("FormatId")]
        public Format Format { get; set; }

        [Display(Name = "Ruling", ResourceType = typeof(StaticResource.Resources))]
        public int RulingId { get; set; }

        [ForeignKey("RulingId")]
        public Ruling Ruling { get; set; }

        [Display(Name = "RulingColor", ResourceType = typeof(StaticResource.Resources))]
        public int RulingColorId { get; set; }

        [ForeignKey("RulingColorId")]
        public RulingColor RulingColor { get; set; }

        [Display(Name = "RulingDetail", ResourceType = typeof(StaticResource.Resources))]       
        public int RulingDetailId { get; set; }

        [ForeignKey("RulingDetailId")]
        public RulingDetail RulingDetail { get; set; }

        [Display(Name = "StringholeHeight", ResourceType = typeof(StaticResource.Resources))]
        public string StringholeHeight { get; set; }

        [Display(Name = "StringholeWidth", ResourceType = typeof(StaticResource.Resources))]
        public string StringholeWidth { get; set; }

        [Display(Name = "DistanceStringholeRight", ResourceType = typeof(StaticResource.Resources))]
        public string DistanceStringholeRight { get; set; }

        [Display(Name = "DistanceStringholeLeft", ResourceType = typeof(StaticResource.Resources))]
        public string DistanceStringholeLeft { get; set; }

        [Display(Name = "InterruptedLine", ResourceType = typeof(StaticResource.Resources))]
        public string InterruptedLine { get; set; }

        //Linguistique

        [AllowHtml]
        [Display(Name = "Transliteration", ResourceType = typeof(StaticResource.Resources))]
        public string Transliteration { get; set; }

        [AllowHtml]
        [Display(Name = "Transcription", ResourceType = typeof(StaticResource.Resources))]
        public string Transcription { get; set; }

        [AllowHtml]
        [Display(Name = "English", ResourceType = typeof(StaticResource.Resources))]
        public string English { get; set; }

        [AllowHtml]
        [Display(Name = "French", ResourceType = typeof(StaticResource.Resources))]
        public string Francaise { get; set; }

        [AllowHtml]
        [Display(Name = "Chinese", ResourceType = typeof(StaticResource.Resources))]
        public string Chinese { get; set; }

        [Display(Name = "Editor", ResourceType = typeof(StaticResource.Resources))]
        public string Editor { get; set; }

        [AllowHtml]
        [Display(Name = "References", ResourceType = typeof(StaticResource.Resources))]
        public string References { get; set; }

        [AllowHtml]
        [Display(Name = "PhilologicalCommentary", ResourceType = typeof(StaticResource.Resources))]
        public string PhilologicalCommentary { get; set; }

        //Material
        [Display(Name = "Material", ResourceType = typeof(StaticResource.Resources))]       
        public int MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public Material Material { get; set; }

        [Display(Name = "PaperColor", ResourceType = typeof(StaticResource.Resources))]
        public int PaperColorId { get; set; }

        [ForeignKey("PaperColorId")]
        public PaperColor PaperColor { get; set; }

        [Display(Name = "PaperThickness", ResourceType = typeof(StaticResource.Resources))]
        public string PaperThickness { get; set; }

        [Display(Name = "WritingTool", ResourceType = typeof(StaticResource.Resources))]
        public int WritingToolId { get; set; }

        [ForeignKey("WritingToolId")]
        public WritingTool WritingTool { get; set; }
        //Script
        [Display(Name = "AlignmentType", ResourceType = typeof(StaticResource.Resources))]    
        public int AlignmentTypeId { get; set; }

        [ForeignKey("AlignmentTypeId")]
        public AlignmentType AlignmentType { get; set; }

        [Display(Name = "ModuleWidth", ResourceType = typeof(StaticResource.Resources))]
        public string ModuleWidth { get; set; }

        [Display(Name = "ModuleHeight", ResourceType = typeof(StaticResource.Resources))]
        public string ModuleHeight { get; set; }

        [Display(Name = "AvCharPerLigne", ResourceType = typeof(StaticResource.Resources))]
        public string AvCharPerLigne { get; set; }

        [Display(Name = "NibThickness", ResourceType = typeof(StaticResource.Resources))]
        public string NibThickness { get; set; }

        [Display(Name = "Script", ResourceType = typeof(StaticResource.Resources))]       
        public int ScriptId { get; set; }

        [ForeignKey("ScriptId")]
        public Script Script { get; set; }

        [Display(Name = "ScriptAdd", ResourceType = typeof(StaticResource.Resources))]
        public int ScriptAddId { get; set; }

        [ForeignKey("ScriptAddId")]
        public ScriptAdd ScriptAdd { get; set; }

        //Text language
        [Display(Name = "TochLanguage", ResourceType = typeof(StaticResource.Resources))]
        public int TochLanguageId { get; set; }

        [ForeignKey("TochLanguageId")]
        public TochLanguage TochLanguage { get; set; }

        [Display(Name = "LanguageStage", ResourceType = typeof(StaticResource.Resources))]
        public int LanguageStageId { get; set; }

        [ForeignKey("LanguageStageId")]
        public LanguageStage LanguageStage { get; set; }

        [Display(Name = "LanguageAdd", ResourceType = typeof(StaticResource.Resources))]        
        public int LanguageDetailId { get; set; }

        [ForeignKey("LanguageDetailId")]
        public LanguageDetail LanguageDetail { get; set; }

        //Text Content
        [Display(Name = "TextGenre", ResourceType = typeof(StaticResource.Resources))]       
        public int GenderManuscriptId { get; set; }

        [ForeignKey("GenderManuscriptId")]
        public GenderManuscript GenderManuscript { get; set; }

        [Display(Name = "TextSubgenre", ResourceType = typeof(StaticResource.Resources))]             
        public int SubGenderManuscriptId { get; set; }

        [ForeignKey("SubGenderManuscriptId")]
        public SubGenderManuscript SubGenderManuscript { get; set; }

        [Display(Name = "TitleArticle", ResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }

        [Display(Name = "Passage", ResourceType = typeof(StaticResource.Resources))]
        public string Passage { get; set; }

        [Display(Name = "Parallel", ResourceType = typeof(StaticResource.Resources))]
        public string Parallel { get; set; }

        [Display(Name = "MetricForm", ResourceType = typeof(StaticResource.Resources))]       
        public int MetricId { get; set; }

        [ForeignKey("MetricId")]
        public Metric Metric { get; set; }

        [Display(Name = "Tune", ResourceType = typeof(StaticResource.Resources))]
        public string Tune { get; set; }

        public ICollection<ImageManuscript> ImageManuscripts { get; set; }

        [AllowHtml]
        [Display(Name = "CEToM")]
        public string Cetom { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }
       
    }
}