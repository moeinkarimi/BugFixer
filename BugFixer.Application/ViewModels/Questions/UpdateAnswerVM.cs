using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Questions
{
    public class UpdateAnswerVM
    {
        [Display(Name = "متن جواب")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string Text { get; set; }
        public int AnswerId { get; set; }
    }
}
