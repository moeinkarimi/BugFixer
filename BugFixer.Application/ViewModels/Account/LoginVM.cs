using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Account
{
    public class LoginVM
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [EmailAddress(ErrorMessage = "{0} وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]  
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
