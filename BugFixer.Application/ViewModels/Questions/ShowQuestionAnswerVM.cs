using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Questions
{
    public class ShowQuestionAnswerVM
    {
        public int? AnswerId { get; set; }
        public string? Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string? SenderName { get; set; }
        public string? SenderAvatar { get; set; }
        public int? NumberOfQuestionSender { get; set; }
        public int? NumberOfAnswersSender { get; set; }
        public int? SenderId { get; set; }
    }
}
