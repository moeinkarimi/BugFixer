using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Account
{
    public class ChangePasswordVM
    {
     
        [Display(Name = "رمز عبور قدیمی")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(50)]
        [MinLength(6, ErrorMessage = "طول {0} حداقل {1} میباشد")]
        public string OldPassword { get; set; }
        [Display(Name = "رمز عبور جدید")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(50)]
        [MinLength(6, ErrorMessage = "طول {0} حداقل {1} میباشد")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار رمز عبور جدید")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی میباشد")]
        [StringLength(50)]
        [Compare("NewPassword", ErrorMessage = "رمز عبور وارد شده یکسان نیست")]
        public string RepeatNewPassword { get; set; }
    }
}
