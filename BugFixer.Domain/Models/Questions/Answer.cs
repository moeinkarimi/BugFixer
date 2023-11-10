using BugFixer.Domain.Models.Base;
using BugFixer.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Questions
{
    public class Answer:BaseEntity
    {
        [Display(Name ="متن جواب")]
        [Required(ErrorMessage ="{0}الزامی می باشد")]
        public string Text { get; set; }


        public int QuestionId { get; set; }
        public int UserId { get; set; }


        #region Relations
        [ForeignKey(nameof(QuestionId))]
        public Question? Question { get; set; }
        public User.User? User { get; set; }
        #endregion
    }
}
