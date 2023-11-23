using BugFixer.Domain.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Interfaces
{
    public interface ITrueAnswerRepository
    {
        Task CreateTrueAnswerAsync(TrueAnswer trueAnswer);
        Task<TrueAnswer> GetTrueAnswerAsync(int qID);
        void DeleteTrueAnswerAsync(TrueAnswer trueAnswer);
    }
}
