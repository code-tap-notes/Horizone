using Horizone.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Horizone.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Display(Name = "Title", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired",ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]		
        public string Title { get; set; }

        [Display(Name = "LastName", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]	
        public string LastName { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]		
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]
        public string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(StaticResource.Resources))]       
        [RegularExpression(@"^([0-9])*\s*$")]
        [StringLength(20, MinimumLength = 3, ErrorMessageResourceName = "MinLength", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string PhoneNumber { get; set; }

        [Display(Name = "SendDate", ResourceType = typeof(StaticResource.Resources))]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessageResourceName = "FieldRequired",ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Column(TypeName ="datetime2")]       
        public DateTime SendDate { get; set; }

        [AllowHtml]
        public string Message { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string SymbolLanguage  { get; set; }


    }
}