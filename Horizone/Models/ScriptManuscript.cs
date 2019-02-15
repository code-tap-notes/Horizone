using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ScriptManuscript
    {
        public int Id { get; set; }

        [Display(Name = "AlignmentType", ResourceType = typeof(StaticResource.Resources))]
        public string AlignmentType { get; set; }

        [Display(Name = "ModuleWidth", ResourceType = typeof(StaticResource.Resources))]
        public string ModuleWidth { get; set; }

        [Display(Name = "ModuleHeight", ResourceType = typeof(StaticResource.Resources))]
        public string ModuleHeight { get; set; }

        [Display(Name = "AvCharPerLigne", ResourceType = typeof(StaticResource.Resources))]
        public string AvCharPerLigne { get; set; }

        [Display(Name = "NibThickness", ResourceType = typeof(StaticResource.Resources))]
        public string NibThickness { get; set; }

        [Display(Name = "Script", ResourceType = typeof(StaticResource.Resources))]
        public string Script { get; set; }

        [Display(Name = "ScriptAdd", ResourceType = typeof(StaticResource.Resources))]
        public string ScriptAdd { get; set; }

        public ICollection<Manuscript> Manuscripts { get; set; }

    }
}
 