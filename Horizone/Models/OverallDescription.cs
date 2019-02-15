using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class OverallDescription
    {
        public int Id { get; set; }

        [Display(Name = "Collection", ResourceType = typeof(StaticResource.Resources))]
        public string Collection { get; set; }

        [Display(Name = "Siglum", ResourceType = typeof(StaticResource.Resources))]
        public string Siglum { get; set; }

        [Display(Name = "Joint", ResourceType = typeof(StaticResource.Resources))]
        public string Joint { get; set; }

        [Display(Name = "OtherSiglum", ResourceType = typeof(StaticResource.Resources))]
        public string OtherSiglum { get; set; }

        [Display(Name = "ExpeditionCode", ResourceType = typeof(StaticResource.Resources))]
        public string ExpeditionCode { get; set; }

        [Display(Name = "MainFindSpot",ResourceType = typeof(StaticResource.Resources))]
        public string MainFindSpot { get; set; }

        [Display(Name = "SpecificFindSpot", ResourceType = typeof(StaticResource.Resources))]
        public string SpecificFindSpot { get; set; }
        
        [Display(Name = "GeneralState", ResourceType = typeof(StaticResource.Resources))]
        public string GeneralState { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [Display(Name = "Remark", ResourceType = typeof(StaticResource.Resources))]
        public string Remark { get; set; }

        [Display(Name = "LeafNumber", ResourceType = typeof(StaticResource.Resources))]
        public string LeafNumber { get; set; }

        public ICollection<Manuscript> Manuscripts { get; set; }
       
    }
}