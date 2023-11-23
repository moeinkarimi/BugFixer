using BugFixer.Data.Context;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Questions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Data.Repository
{
    public class TrueAnswerRepository : ITrueAnswerRepository
    {
        private readonly BugFixerDBContext _ctx;
        public TrueAnswerRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task CreateTrueAnswerAsync(TrueAnswer trueAnswer)
        {
           await _ctx.TrueAnswers.AddAsync(trueAnswer);
        }

        public void DeleteTrueAnswerAsync(TrueAnswer trueAnswer)
        {
            _ctx.TrueAnswers.Remove(trueAnswer);
        }

        public async Task<TrueAnswer> GetTrueAnswerAsync(int qID)
        {
            return await _ctx.TrueAnswers
                 .FirstOrDefaultAsync(tr => tr.QuestionId==qID);
        }
    }
}
