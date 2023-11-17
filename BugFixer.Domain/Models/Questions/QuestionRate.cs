using BugFixer.Domain.Models.Base;
using BugFixer.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Questions
{
    public class QuestionRate:BaseEntity
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }

        [ForeignKey("UserId")]
        public User.User? User { get; set; }
    }
}
