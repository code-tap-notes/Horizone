using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class Collaboration
    {
        public int Id { get; set; }

        [RegularExpression(@"([a-zA-Z])*\s*$", ErrorMessage = "Le champ {0} ne doit contenir que des lettres / Only letters")]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "MaxLength20", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Title", ResourceType = typeof(StaticResource.Resources))]       
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "LastName", ResourceType = typeof(StaticResource.Resources))]      
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "FirstName", ResourceType = typeof(StaticResource.Resources))]
        public string FirstName { get; set; }

        [AllowHtml]
        [Display(Name = "Summary", ResourceType = typeof(StaticResource.Resources))]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MaxLength500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Summary { get; set; }

        [Display(Name = "CVName")]
        [StringLength(500, MinimumLength = 1, ErrorMessageResourceName = "MaxLength500", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string CV { get; set; }

        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]        
        public string Email { get; set; }

        [Display(Name = "Publications", ResourceType = typeof(StaticResource.Resources))]
        public ICollection<Publication> Publications { get; set; }

        [Display(Name = "Picture", ResourceType = typeof(StaticResource.Resources))]        
        public ICollection<ImageCollaboration> ImageCollaborations { get; set; }

        [Display(Name = "Team", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Team { get; set; }

        [Display(Name = "Visible", ResourceType = typeof(StaticResource.Resources))]
        public Boolean Visible { get; set; }

    }
}