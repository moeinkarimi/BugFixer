using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Questions
{
    public class CreateQuestionVM
    {
        [Display(Name = "عنوان سوال")]
        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string Title { get; set; }
        [Display(Name = "متن سوال")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string Text { get; set; }
        public string Tag { get; set; }

    }
}
