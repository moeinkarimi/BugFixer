using BugFixer.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Models.Questions
{
    public class TrueAnswer:BaseEntity
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }

        #region Relations
        [ForeignKey(nameof(QuestionId))]
        public Question? Question { get; set; }
        [ForeignKey(nameof(AnswerId))]
        public Answer? Answer { get; set; }
        #endregion
    }
}
