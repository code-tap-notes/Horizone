using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Horizone.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessageResourceName = "MaxLength50", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [DataType(DataType.Password)]
        [Display(Name = "NewPass", ResourceType = typeof(StaticResource.Resources))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(StaticResource.Resources))]
        [Compare("NewPassword", ErrorMessageResourceName = "ConfirmError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "CurrentPassword", ResourceType = typeof(StaticResource.Resources))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "MaxLength50", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        [DataType(DataType.Password)]
        [Display(Name = "NewPass", ResourceType = typeof(StaticResource.Resources))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(StaticResource.Resources))]
        [Compare("NewPassword", ErrorMessageResourceName = "ConfirmError", ErrorMessageResourceType = typeof(StaticResource.Resources))]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(StaticResource.Resources))]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code", ResourceType = typeof(StaticResource.Resources))]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "PhoneNumber", ResourceType = typeof(StaticResource.Resources))]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}