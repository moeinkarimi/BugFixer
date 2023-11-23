using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Questions
{
    public class Question:BaseEntity
    {
        [Display(Name ="عنوان سوال")]
        [MaxLength(400,ErrorMessage ="تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage ="{0}الزامی می باشد")]
        public string Title { get; set; }
        [Display(Name ="متن سوال")]
        [Required(ErrorMessage ="{0}الزامی می باشد")]
        public string Text { get; set; }
        public int UserId { get; set; }
        public int Visit { get; set; } = 0;

        #region Relations
        [ForeignKey("UserId")]
        public User.User? User { get; set; }
        public IEnumerable<QuestionTag>? QuestionTags { get; set; }
        public IEnumerable<Answer>? Answers { get; set; }
        public IEnumerable<QuestionRate>? QuestionRates { get; set; }
        public TrueAnswer? TrueAnswer { get; set; }
        #endregion
    }
}
