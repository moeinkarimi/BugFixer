using BugFixer.Data.Context;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Questions;
using Microsoft.EntityFrameworkCore;

namespace BugFixer.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly BugFixerDBContext _ctx;
        public QuestionRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAnswerAsync(Answer answer)
        {
            await _ctx.Answers.AddAsync(answer);
        }

        public async Task CreateQuestionAsync(Question quesion)
        {
            await _ctx.Questions.AddAsync(quesion);
        }

        public async Task CreateQuestionTagAsync(QuestionTag questionTag)
        {
            await _ctx.QuestionTags.AddAsync(questionTag);
        }

        public async Task<Answer> GetAnswerById(int id)
        {

            return await _ctx.Answers.FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<Question> GetQuestionAsync(int id)
        {
            return await _ctx.Questions.Include(q=> q.QuestionTags)
                .Include(q=> q.Answers)
                .Include(q=> q.User)
                .ThenInclude(u=> u.Answers)
                .Include(q=> q.User)
                .ThenInclude(u=> u.Questions)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync()
        {
            return await _ctx.Questions.Include(q => q.User)
                .Include(q=> q.QuestionTags)
                .Include(q => q.Answers)
                .ThenInclude(a=> a.User)
                .ToListAsync();
        }

        public  IQueryable<Answer> QuestionAnswersQueryable(int id)
        {
            return _ctx.Answers.Include(a=> a.User).ThenInclude(u=> u.Answers)
                .Include(a=> a.User).ThenInclude(u=> u.Questions)
                .Where(a=> a.QuestionId==id).AsQueryable();
        }

        public async Task<int> GetUserAnswersCountAsync(int userId)
        {
            return _ctx.Questions
                .Where(q => q.UserId == userId)
                .SelectMany(q => q.Answers)
                .Count();
        }

        public async Task<int> GetUserQuestionsCountAsync(int userId)
        {
            return _ctx.Questions
                .Where(q => q.UserId == userId)
                .Count();
        }

        public async Task SavechangeAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public void UpdateAnswer(Answer answer)
        {
            _ctx.Answers.Update(answer);
        }

        public void UpdateQuestion(Question question)
        {
            _ctx.Questions.Update(question);
        }
    }
}
