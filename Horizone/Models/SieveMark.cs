using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class SieveMark
    {
        public int Id { get; set; }

        [Display(Name = "SieveMark", ResourceType = typeof(StaticResource.Resources))]
        public string SieveMarkEn { get; set; }

        [Display(Name = "SieveMark", ResourceType = typeof(StaticResource.Resources))]
        public string SieveMarkFr { get; set; }

        [Display(Name = "SieveMark", ResourceType = typeof(StaticResource.Resources))]
        public string SieveMarkZh { get; set; }
    }
}