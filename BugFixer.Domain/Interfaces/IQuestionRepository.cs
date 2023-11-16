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
        Task SavechangeAsync();


        Task<IEnumerable<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionAsync(int id);
        Task CreateQuestionAsync(Question quesion);
        Task CreateAnswerAsync(Answer answer);
        Task CreateQuestionTagAsync(QuestionTag questionTag);
        void UpdateQuestion(Question question);

        IQueryable<Answer> QuestionAnswersQueryable(int id);

        void UpdateAnswer(Answer answer);
        Task<Answer> GetAnswerById(int id);
        


    }
}
