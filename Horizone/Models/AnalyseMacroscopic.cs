using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class AnalyseMacroscopic
    {
        public int Id { get; set; }

        //General Information
        [Display(Name = "Catalogue", ResourceType = typeof(StaticResource.Resources))]
        public int CatalogieId { get; set; }

        [ForeignKey("CatalogieId")]
        public Catalogie Catalogie { get; set; }

        [Display(Name = "Index")]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Index { get; set; }

        [Display(Name = "FindingPlace", ResourceType = typeof(StaticResource.Resources))]
        public int MapId { get; set; }

        [ForeignKey("MapId")]
        public Map Map { get; set; }

        [Display(Name = "EstimatedDateProduction", ResourceType = typeof(StaticResource.Resources))]
        public string EstimatedDateProduction { get; set; }

        [Display(Name = "PlaceProduction", ResourceType = typeof(StaticResource.Resources))]
        public string PlaceProduction{ get; set; }

        [Display(Name = "TitleArticle", ResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }

        [Display(Name = "Theme", ResourceType = typeof(StaticResource.Resources))]
        public int GenderManuscriptId { get; set; }

        [ForeignKey("GenderManuscriptId")]
        public GenderManuscript GenderManuscript { get; set; }

        [Display(Name = "GeneralState", ResourceType = typeof(StaticResource.Resources))]
        public int StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        [Display(Name = "TochLanguage", ResourceType = typeof(StaticResource.Resources))]
        public int TochLanguageId { get; set; }

        [ForeignKey("TochLanguageId")]
        public TochLanguage TochLanguage { get; set; }

        //Sheet Description

        [Display(Name = "Format", ResourceType = typeof(StaticResource.Resources))]
        public int FormatId { get; set; }

        [ForeignKey("FormatId")]
        public Format Format { get; set; }

        [Display(Name = "NumberOfHoles", ResourceType = typeof(StaticResource.Resources))]
        public int NumberOfHoles { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [Display(Name = "AverageThickness", ResourceType = typeof(StaticResource.Resources))]
        public string AverageThickness { get; set; }

        [Display(Name = "Correction", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Correction { get; set; }

        [Display(Name = "SheetCondition", ResourceType = typeof(StaticResource.Resources))]
        public string SheetCondition { get; set; }
      
        [Display(Name = "NeedForConservation", ResourceType = typeof(StaticResource.Resources))]
        public string NeedForConservation { get; set; }

        [AllowHtml]
        [Display(Name = "Observation", ResourceType = typeof(StaticResource.Resources))]
        public string Observation { get; set; }

        [Display(Name = "Restore", ResourceType = typeof(StaticResource.Resources))]
        public int RestoreId { get; set; }

        [ForeignKey("RestoreId")]
        public Restore Restore { get; set; }

        //Layout

        [Display(Name = "Ruling", ResourceType = typeof(StaticResource.Resources))]
        public int RulingId { get; set; }

        [ForeignKey("RulingId")]
        public Ruling Ruling { get; set; }

        [Display(Name = "NumberOfLine", ResourceType = typeof(StaticResource.Resources))]
        public int NumberOfLine { get; set; }

        [Display(Name = "Script", ResourceType = typeof(StaticResource.Resources))]
        public int ScriptId { get; set; }

        [ForeignKey("ScriptId")]
        public Script Script { get; set; }

        [Display(Name = "PageFrame", ResourceType = typeof(StaticResource.Resources))]
        public string PageFrame { get; set; }
        //Macroscopic Analysic
        [Display(Name = "PaperColor", ResourceType = typeof(StaticResource.Resources))]
        public int PaperColorId { get; set; }

        [ForeignKey("PaperColorId")]
        public PaperColor PaperColor { get; set; }

        [Display(Name = "WritingTool", ResourceType = typeof(StaticResource.Resources))]
        public int WritingToolId { get; set; }

        [ForeignKey("WritingToolId")]
        public WritingTool WritingTool { get; set; }

        [Display(Name = "SoftQuality", ResourceType = typeof(StaticResource.Resources))]
        public Boolean SoftQuality { get; set; }

        [Display(Name = "RattleQuality", ResourceType = typeof(StaticResource.Resources))]
        public Boolean RattleQuality { get; set; }

        [Display(Name = "Transparency", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Transparency { get; set; }

        [Display(Name = "SurfaceAspect", ResourceType = typeof(StaticResource.Resources))]
        public string SurfaceAspect { get; set; }

        [Display(Name = "CoatingColor", ResourceType = typeof(StaticResource.Resources))]
        public int RulingColorId { get; set; }

        [ForeignKey("RulingColorId")]
        public RulingColor RulingColor { get; set; }

        [Display(Name = "CoatingDecayingCondition", ResourceType = typeof(StaticResource.Resources))]
        public string CoatingDecayingCondition { get; set; }

        [Display(Name = "ClayOrSandParticules", ResourceType = typeof(StaticResource.Resources))]
        public Boolean ClayOrSandParticules { get; set; }
        
        [Display(Name = "SurfaceOnBothSides", ResourceType = typeof(StaticResource.Resources))]
        public Boolean SurfaceOnBothSides { get; set; }

        [Display(Name = "TransmittedLight", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<TransmittedLight> TransmittedLights { get; set; }

        [Display(Name = "FiberDistribution", ResourceType = typeof(StaticResource.Resources))]
        public int FiberDistributionId { get; set; }

        [ForeignKey("FiberDistributionId")]
        public FiberDistribution FiberDistribution { get; set; }

        [Display(Name = "NumberLayer", ResourceType = typeof(StaticResource.Resources))]
        public string NumberLayer { get; set; }

        [Display(Name = "SieveMark", ResourceType = typeof(StaticResource.Resources))]
        public int SieveMarkId { get; set; }

        [ForeignKey("SieveMarkId")]
        public SieveMark SieveMark { get; set; }

        [Display(Name = "FiberDirection", ResourceType = typeof(StaticResource.Resources))]
        public int FiberDirectionId { get; set; }

        [ForeignKey("FiberDirectionId")]
        public FiberDirection FiberDirection { get; set; }

        [Display(Name = "LaidLinesRegularity", ResourceType = typeof(StaticResource.Resources))]
        public int LaidLinesRegularityId { get; set; }

        [ForeignKey("LaidLinesRegularityId")]
        public LaidLinesRegularity LaidLinesRegularity { get; set; }

        [Display(Name = "NumberChainLinePerCm", ResourceType = typeof(StaticResource.Resources))]
        public int NumberChainLinePerCm { get; set; }

        [Display(Name = "ChainLinesVisibility", ResourceType = typeof(StaticResource.Resources))]
        public int ChainLinesVisibilityId { get; set; }

        [ForeignKey("ChainLinesVisibilityId")]
        public ChainLinesVisibility ChainLinesVisibility { get; set; }

        [Display(Name = "SpaceBetweenLines", ResourceType = typeof(StaticResource.Resources))]
        public string SpaceBetweenLines { get; set; }

        [Display(Name = "Drying", ResourceType = typeof(StaticResource.Resources))]
        public int DryingId { get; set; }

        [ForeignKey("DryingId")]
        public Drying Drying { get; set; }

        [Display(Name = "PreparationPaperBeforeUsing", ResourceType = typeof(StaticResource.Resources))]
        public int PreparationPaperBeforeUsingId { get; set; }

        [ForeignKey("PreparationPaperBeforeUsingId")]
        public PreparationPaperBeforeUsing PreparationPaperBeforeUsing { get; set; }

        [Display(Name = "ManufaturingDefect", ResourceType = typeof(StaticResource.Resources))]
        public int ManufaturingDefectId { get; set; }

        [ForeignKey("ManufaturingDefectId")]
        public ManufaturingDefect ManufaturingDefect { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }


    }
}