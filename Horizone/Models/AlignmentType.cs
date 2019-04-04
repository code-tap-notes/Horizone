using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class AlignmentType
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "AlignmentTypeEn", ResourceType = typeof(StaticResource.Resources))]
        public string AlignmentTypeEn { get; set; }

        [AllowHtml]
        [Display(Name = "AlignmentTypeFr", ResourceType = typeof(StaticResource.Resources))]
        public string AlignmentTypeFr { get; set; }

        [AllowHtml]
        [Display(Name = "AlignmentTypeZh", ResourceType = typeof(StaticResource.Resources))]
        public string AlignmentTypeZh { get; set; }
    }
}