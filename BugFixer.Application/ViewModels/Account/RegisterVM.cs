using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Account
{
    public class RegisterVM
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "{0} وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [RegularExpression("^(\\+98|0)?9\\d{9}$", ErrorMessage ="لطفا یک شماره موبایل معتبر وارد کنید")]
        public string? Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(50)]
        [MinLength(6, ErrorMessage = "طول {0} حداقل {1} میباشد")]
        public string Password { get; set; }

        [Display(Name = "تکراررمزعبور")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(50)]
        [Compare("Password", ErrorMessage ="رمز عبور وارد شده یکسان نیست")]
        public string RepeatPassword { get; set; }
    }
}
