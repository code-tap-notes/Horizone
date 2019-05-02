using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class Restore
    {
        public int Id { get; set; }

        [Display(Name = "Restore", ResourceType = typeof(StaticResource.Resources))]
        public string RestoreEn { get; set; }

        [Display(Name = "Restore", ResourceType = typeof(StaticResource.Resources))]
        public string RestoreFr { get; set; }

        [Display(Name = "Restore", ResourceType = typeof(StaticResource.Resources))]
        public string RestoreZh { get; set; }

    }
}