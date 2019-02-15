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

        [Display(Name = "Index")]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Index { get; set; }

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
       
        [Display(Name = "References", ResourceType = typeof(StaticResource.Resources))]
        public string References { get; set; }

        [AllowHtml]
        [Display(Name = "PhilologicalCommentary", ResourceType = typeof(StaticResource.Resources))]
        public string PhilologicalCommentary { get; set; }

        [Display(Name = "ScriptManuscript", ResourceType = typeof(StaticResource.Resources))]       
        public int ScriptManuscriptId { get; set; }

        [ForeignKey("ScriptManuscriptId")]
        public ScriptManuscript ScriptManuscript { get; set; }

        [Display(Name = "Content", ResourceType = typeof(StaticResource.Resources))]  
        public int TextContentId { get; set; }

        [AllowHtml]
        [ForeignKey("TextContentId")]
        public TextContent TextContent { get; set; }

        [Display(Name = "Material", ResourceType = typeof(StaticResource.Resources))]
        public int MaterialManuscriptId { get; set; }

        [ForeignKey("MaterialManuscriptId")]
        public MaterialManuscript MaterialManuscript { get; set; }

        [Display(Name = "OverallDescription", ResourceType = typeof(StaticResource.Resources))]
        public int OverallDescriptionId { get; set; }

        [ForeignKey("OverallDescriptionId")]
        public OverallDescription OverallDescription { get; set; }

        [Display(Name = "LayoutManuscript", ResourceType = typeof(StaticResource.Resources))]
        public int LayoutManuscriptId { get; set; }

        [ForeignKey("LayoutManuscriptId")]
        public LayoutManuscript LayoutManuscript { get; set; }

        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        public int TextLanguageId { get; set; }

        [ForeignKey("TextLanguageId")]
        public TextLanguage TextLanguage { get; set; }

        public ICollection<ImageManuscript> ImageManuscripts { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Bibliography> Bibliographys { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }

    }
}