using BugFixer.Domain.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);
        Task CreateQuestion(Question quesion);
        Task CreateAnswer(Answer answer);


    }
}
