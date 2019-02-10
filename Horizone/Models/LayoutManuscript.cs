using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class LayoutManuscript
    {
        public int Id { get; set; }


        [Display(Name = "SizeHeight", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string SizeHeight { get; set; }

        [Display(Name = "Completeness", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Completeness { get; set; }

        [Display(Name = "SizeWidth", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string SizeWidth { get; set; }

        [Display(Name = "NumberOfLine", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 1000, ErrorMessageResourceName = "NegativeError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int NumberOfLine { get; set; }

        [Display(Name = "LineDistance", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string LineDistance { get; set; }

        [Display(Name = "Format", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Format { get; set; }

        [Display(Name = "Ruling", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Ruling { get; set; }

        [Display(Name = "RulingColor", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(40, MinimumLength = 1, ErrorMessageResourceName = "MaxLength40", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string RulingColor { get; set; }

        [Display(Name = "RulingDetail", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 1000, ErrorMessageResourceName = "NegativeError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int RulingDetail { get; set; }


        [Display(Name = "StringholeHeight", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 1000, ErrorMessageResourceName = "NegativeError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int StringholeHeight { get; set; }

        [Display(Name = "StringholeWidth", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 1000, ErrorMessageResourceName = "NegativeError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int StringholeWidth { get; set; }

        [Display(Name = "DistanceStringholeRight", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 1000, ErrorMessageResourceName = "NegativeError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int DistanceStringholeRight { get; set; }

        [Display(Name = "DistanceStringholeLeft", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 1000, ErrorMessageResourceName = "NegativeError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int DistanceStringholeLeft { get; set; }

        [Display(Name = "InterruptedLine", ResourceType = typeof(StaticResource.Resources))]
        [Range(0, 1000, ErrorMessageResourceName = "NegativeError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public int InterruptedLine { get; set; }

        public ICollection<Manuscript> Manuscripts { get; set; }
    }
}