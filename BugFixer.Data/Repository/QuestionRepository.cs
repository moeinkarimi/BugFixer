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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly BugFixerDBContext _ctx;
        public QuestionRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAnswer(Answer answer)
        {
            await _ctx.Answers.AddAsync(answer);
        }

        public async Task CreateQuestion(Question quesion)
        {
            await _ctx.Questions.AddAsync(quesion);
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await _ctx.Questions.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _ctx.Questions.Include(q => q.User).Include(q => q.Answers).ToListAsync();
        }
    }
}
