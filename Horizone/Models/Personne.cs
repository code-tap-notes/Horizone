using Horizone.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Horizone.Models
{
	public abstract class Personne
	{
		public int Id { get; set; }
   
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "MaxLength20", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Title", ResourceType = typeof(StaticResource.Resources))]
        [Index("IX_PersonneUnique", 1, IsUnique = true)]
		public string Title { get; set; }
             		
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "LastName", ResourceType = typeof(StaticResource.Resources))]
        [Index("IX_PersonneUnique", 2, IsUnique = true)]
		public string LastName { get; set; }
     		
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "FirstName", ResourceType = typeof(StaticResource.Resources))]
        [Index("IX_PersonneUnique", 3, IsUnique = true)]
		public string FirstName { get; set; }
         
        [RegularExpression(@"^([0-9])*\s*$", ErrorMessageResourceName = "OnlyNumbers", ErrorMessageResourceType = typeof(StaticResource.Resources))]       
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(20, MinimumLength = 3, ErrorMessageResourceName = "MaxLength20", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "PhoneNumber", ResourceType = typeof(StaticResource.Resources))]
        public string PhoneNumber { get; set; }
        		
	}
}