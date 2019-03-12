using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class TochLanguage
    {
        public int Id { get; set; }

        [Display(Name = "TochLanguage", ResourceType = typeof(StaticResource.Resources))]
        public string Language { get; set; }

    }
}