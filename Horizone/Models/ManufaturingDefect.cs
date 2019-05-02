using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class ManufaturingDefect
    {
        public int Id { get; set; }

        [Display(Name = "ManufaturingDefect", ResourceType = typeof(StaticResource.Resources))]
        public string ManufaturingDefectEn { get; set; }

        [Display(Name = "ManufaturingDefect", ResourceType = typeof(StaticResource.Resources))]
        public string ManufaturingDefectFr { get; set; }

        [Display(Name = "ManufaturingDefect", ResourceType = typeof(StaticResource.Resources))]
        public string ManufaturingDefectZh { get; set; }

    }
}