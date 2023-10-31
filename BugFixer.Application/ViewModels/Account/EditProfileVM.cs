using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Account
{
    public class EditProfileVM
    {
        [StringLength(100, ErrorMessage ="متن وارد شده نمی توتند بیشتر از 100 حرف باشد.")]
        public string?  FirstName{ get; set; }
        [StringLength(100, ErrorMessage = "متن وارد شده نمی توتند بیشتر از 100 حرف باشد.")]
        public string?  LastName{ get; set; }
        [StringLength(350, ErrorMessage = "متن وارد شده نمی توتند بیشتر از 350 حرف باشد.")]
        public string?  AboutMe{ get; set; }

        [RegularExpression("^(\\+98|0)?9\\d{9}$", ErrorMessage = "لطفا یک شماره موبایل معتبر وارد کنید")]
        public string?  Mobile{ get; set; }
    }
}
