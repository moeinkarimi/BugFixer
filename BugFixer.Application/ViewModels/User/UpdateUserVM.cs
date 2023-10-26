using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.User
{
    public class UpdateUserVM:BaseVM.BaseVM
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string Email { get; set; }
        [Display(Name = "موبایل")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string Mobile { get; set; }
        [Display(Name = "رمز عبور")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string Password { get; set; }


    }
}
