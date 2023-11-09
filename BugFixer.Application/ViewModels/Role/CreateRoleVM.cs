using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Role
{
    public class CreateRoleVM:BaseVM.BaseVM
    {

        [Display(Name = "عنوان نقش")]
        [MaxLength(20, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]

        public string Title { get; set; }

    }
}
