using BugFixer.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugFixer.Domain.Models.Questions
{
    public class Answer : BaseEntity
    {
        [Display(Name = "متن جواب")]
        [Required(ErrorMessage = "{0}الزامی می باشد")]
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }


        #region Relations
        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }
        [ForeignKey("UserId")]
        public User.User? User { get; set; }
        #endregion
    }
}
