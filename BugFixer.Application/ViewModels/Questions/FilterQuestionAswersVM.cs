using BugFixer.Application.ViewModels.Common;
using BugFixer.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.ViewModels.Questions
{
    public class FilterQuestionAswersVM:BasePaging<ShowQuestionAnswerVM>
    {

        public string OrderType { get; set; }


    }
}
