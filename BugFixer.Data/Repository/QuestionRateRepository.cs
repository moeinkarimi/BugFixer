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
    public class QuestionRateRepository : IQuestionRateRepository
    {
        private readonly BugFixerDBContext _ctx;
        public QuestionRateRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task CreateQuestionRateAsync(QuestionRate questionRate)
        {
            await _ctx.QuestionRates.AddAsync(questionRate);
        }

        public void DeleteQuestionRate(QuestionRate questionRate)
        {
            _ctx.QuestionRates
                .Remove(questionRate);
        }

        public async Task<QuestionRate> GetQuestionRateAsync(int qID, int userID)
        {
            return await _ctx.QuestionRates
                .FirstOrDefaultAsync(qr => qr.QuestionId == qID && qr.UserId == userID);
        }

     
    }
}
