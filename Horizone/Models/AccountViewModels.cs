using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Horizone.Validators;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace Horizone.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]

        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code", ResourceType = typeof(StaticResource.Resources))]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "RemenberBrowser", ResourceType = typeof(StaticResource.Resources))]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(StaticResource.Resources))]
        public string Password { get; set; }

        [Display(Name = "RememberPassword", ResourceType = typeof(StaticResource.Resources))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessageResourceName = "Min2", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(StaticResource.Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(StaticResource.Resources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"([a-zA-Z])*\s*$", ErrorMessageResourceName = "OnlyLetters", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "Title", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "MaxLength20", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string Title { get; set; }

        [RegularExpression(@"([a-zA-Zéàèïëüêâîôöç\-\s])*$", ErrorMessageResourceName = "OnlyLetters", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "LastName", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string LastName { get; set; }

        [RegularExpression(@"([a-zA-Zéàèïëüêâîôöç\-\s])*$", ErrorMessageResourceName = "OnlyLetters", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [Display(Name = "FirstName", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(30, MinimumLength = 2, ErrorMessageResourceName = "MaxLength30", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string FisrtName { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(StaticResource.Resources))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [RegularExpression(@"^([0-9])*\s*$", ErrorMessageResourceName = "OnlyNumbers", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [StringLength(20, MinimumLength = 3, ErrorMessageResourceName = "MaxLength20", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string PhoneNumber { get; set; }

    }

        public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "Min2", ErrorMessageResourceType = typeof(StaticResource.Resources), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(StaticResource.Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(StaticResource.Resources))]
        [Compare("Password", ErrorMessageResourceName = "ConfirmError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(StaticResource.Resources))]
        public string Email { get; set; }
    }
}
