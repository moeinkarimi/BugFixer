using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Questions
{
    public class QuestionRateVM : BaseVM.BaseVM
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
