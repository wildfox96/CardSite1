using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CardSite1.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "First_name_required")]
        [Display(Name = "First_name", ResourceType = typeof(Resources.Resource))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "Last_name_required")]
        [Display(Name = "Last_name", ResourceType = typeof(Resources.Resource))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "Login_required")]
        [Display(Name = "Login", ResourceType = typeof(Resources.Resource))]
        public string LoginName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "Email_required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "*")]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "Password_required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                  ErrorMessageResourceName = "Confirm_password_required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm_password", ResourceType = typeof(Resources.Resource))]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}