using BugFixer.Domain.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Interfaces
{
    public interface IQuestionRateRepository
    {
        Task CreateQuestionRateAsync(QuestionRate questionRate);
        Task<QuestionRate> GetQuestionRateAsync(int qID, int userID );
        void DeleteQuestionRate(QuestionRate questionRate);
        Task<bool> IsRateExistAsync(int qID, int userID);
    }
}
