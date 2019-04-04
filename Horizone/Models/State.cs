using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "StateEn", ResourceType = typeof(StaticResource.Resources))]
        public string StateEn { get; set; }

        [Display(Name = "StateFr", ResourceType = typeof(StaticResource.Resources))]
        public string StateFr { get; set; }

        [Display(Name = "StateZh", ResourceType = typeof(StaticResource.Resources))]
        public string StateZh { get; set; }
    }
}