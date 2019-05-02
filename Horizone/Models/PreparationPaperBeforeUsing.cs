using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class PreparationPaperBeforeUsing
    {
        public int Id { get; set; }

        [Display(Name = "PreparationPaperBeforeUsing", ResourceType = typeof(StaticResource.Resources))]
        public string PreparationEn { get; set; }

        [Display(Name = "PreparationPaperBeforeUsing", ResourceType = typeof(StaticResource.Resources))]
        public string PreparationFr { get; set; }

        [Display(Name = "PreparationPaperBeforeUsing", ResourceType = typeof(StaticResource.Resources))]
        public string PreparationZh { get; set; }

    }
}