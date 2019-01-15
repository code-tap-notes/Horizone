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
        [StringLength(40, MinimumLength = 1, ErrorMessage = "L'index  doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Index { get; set; }


        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Language", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Language { get; set; }

        
        [Display(Name = "Script", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Script { get; set; }


        [Display(Name = "Repository", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Repository { get; set; }

        
        [Display(Name = "Shelfmark", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Shelfmark { get; set; }
       

        [Display(Name = "Translate into English")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string TranslateEnglish { get; set; }

        [Display(Name = "Traduction Française ")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string TranslateFrench { get; set; }

        [Display(Name = "中文翻译 ")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string TranslateChinese { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [Display(Name = "Editor", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Editor { get; set; }

        [Display(Name = "Bibliography", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Bibliography { get; set; }

        [Display(Name = "Provenience", ResourceType = typeof(StaticResource.Resources))]       
        public int ProvenienceId { get; set; }

        [ForeignKey("ProvenienceId")]
        public Provenience Provenience { get; set; }

        [Display(Name = "Content", ResourceType = typeof(StaticResource.Resources))]  
        public int TextContentId { get; set; }

        [AllowHtml]
        [ForeignKey("TextContentId")]
        public TextContent TextContent { get; set; }

        [Display(Name = "Object Manuscript")]
        public int ObjectManuscriptId { get; set; }

        [ForeignKey("ObjectManuscriptId")]
        public ObjectManuscript ObjectManuscript { get; set; }

       
        public ICollection<ImageManuscript> ImageManuscripts { get; set; }
    
    }
}