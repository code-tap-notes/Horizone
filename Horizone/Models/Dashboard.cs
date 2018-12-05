using Horizone.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Dashboard
    {
        
        public ICollection<DictionaryTocharian> DictionaryTocharians { get; set; }

        public ICollection<Transcription> Transcriptions { get; set; }

    }
}