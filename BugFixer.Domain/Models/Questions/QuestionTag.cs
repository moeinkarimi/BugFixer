using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Questions
{
    public class QuestionTag:BaseEntity
    {
        [Display(Name ="تگ")]
        [MaxLength(100,ErrorMessage ="تعداد کاراکتر های {0}بیش از {1}کاراکتر است")]
        [Required(ErrorMessage ="{0}الزامی می باشد")]
        public string Tag { get; set; }
        public int QuestionId { get; set; }


        #region Relations
        public Question? Question { get; set; }
        #endregion
    }
}
