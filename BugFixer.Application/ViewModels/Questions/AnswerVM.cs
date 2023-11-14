using BugFixer.Domain.Models.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugFixer.Application.ViewModels.User;

namespace BugFixer.Application.ViewModels.Questions
{
    public class AnswerVM:BaseVM.BaseVM
    {
        [Display(Name = "متن جواب")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string? Text { get; set; }


        public int? QuestionId { get; set; }
        public int? UserId { get; set; }


        #region Relations
        [ForeignKey(nameof(QuestionId))]
        public QuestionVM? Question { get; set; }
        public UserVM? User { get; set; }
        #endregion
    }
}
