using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Transcription
    {
        public int Id { get; set; }

        [Display(Name = "Text", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Text { get; set; }
        
        [Display(Name = "TochStory", ResourceType = typeof(StaticResource.Resources))]
        public int TochStoryId { get; set; }

        [ForeignKey("TochStoryId")]
        public TochStory TochStory { get; set; }

        [Display(Name = "TochPhrase", ResourceType = typeof(StaticResource.Resources))]
        public int TochPhraseId { get; set; }

        [ForeignKey("TochPhraseId")]
        public TochPhrase TochPhrase { get; set; }


        [Display(Name = "Manuscript", ResourceType = typeof(StaticResource.Resources))]       
        public int ManuscriptId { get; set; }

        [ForeignKey("ManuscriptId")]
        public Manuscript Manuscript { get; set; }
     
    }
}