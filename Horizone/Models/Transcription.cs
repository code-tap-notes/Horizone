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

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire. / Field {0} is required")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Le champ doit avoir de 1 a 40 caracteres / At least 1 Character")]
        public string Text { get; set; }
        
        [Display(Name = "TochStory")]
        public int TochStoryId { get; set; }

        [ForeignKey("TochStoryId")]
        public TochStory TochStory { get; set; }

        [Display(Name = "TochPhrase")]
        public int TochPhraseId { get; set; }

        [ForeignKey("TochPhraseId")]
        public TochPhrase TochPhrase { get; set; }


        [Display(Name = "Manuscript")]       
        public int ManuscriptId { get; set; }

        [ForeignKey("ManuscriptId")]
        public Manuscript Manuscript { get; set; }
     
    }
}