using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class PartnerAndRelation
    {
        public int Id { get; set; }

        [AllowHtml]
        [Display(Name = "Name", ResourceType = typeof(StaticResource.Resources))]
        public string Name { get; set; }

        [AllowHtml]
        [Display(Name = "Description", ResourceType = typeof(StaticResource.Resources))]
        public string Description { get; set; }

        [AllowHtml]
        [Display(Name = "Link", ResourceType = typeof(StaticResource.Resources))]
        public string Link { get; set; }

        [Display(Name = "Partner", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Partner { get; set; }

        [Display(Name = "RelationInternational", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Relation { get; set; }

        [Display(Name = "Order", ResourceType = typeof(StaticResource.Resources))]
        public int Order { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }

        [Display(Name = "Picture", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<ImagePartner> ImagePartners { get; set; }

    }
}