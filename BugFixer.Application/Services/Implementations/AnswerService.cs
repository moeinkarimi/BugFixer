using BugFixer.Application.Services.Interfaces;
using BugFixer.Domain.Interfaces;

namespace BugFixer.Application.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }
    }
}
