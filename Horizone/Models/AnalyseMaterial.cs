using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
    public class AnalyseMaterial
    {
        public int Id { get; set; }

        [Display(Name = "Index", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Index { get; set; }

        [Display(Name = "ImageUV", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<ImageUV> ImageUVs { get; set; }

        [Display(Name = "OtherImage", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<ImageAnalyse> ImageAnalyses { get; set; }

        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        public int Order { get; set; }
    }
}