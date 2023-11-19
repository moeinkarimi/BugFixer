using BugFixer.Application.ViewModels.Questions;
using BugFixer.Application.ViewModels.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.User
{
    public class ProfileVM
    {
        public UserVM? User { get; set; }
        public List<QuestionVM>? Questions  { get; set; }
        public List<AnswerVM>? Answers { get; set; }
        public ResumeVM? Resume { get; set; }
        public int QuestionRateCount { get; set; }


    }
}
