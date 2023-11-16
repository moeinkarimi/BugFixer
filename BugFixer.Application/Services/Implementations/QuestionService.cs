using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Questions;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task CreateAnswerServiceAsync(string answerText,int questionId,int userId)
        {
            Answer answer = new Answer()
            {
                Text = answerText,
                QuestionId = questionId,
                UserId = userId
            };

            await _questionRepository.CreateAnswerAsync(answer);
            await _questionRepository.SavechangeAsync();
        }

        public async Task CreateQuestionServiceAsync(CreateQuestionVM quesion,int userId)
        {
            Question newQuestion = new Question()
            {
                Title = quesion.Title,
                Text = quesion.Text,
                UserId = userId

            };

            await _questionRepository.CreateQuestionAsync(newQuestion);
            await _questionRepository.SavechangeAsync();

            List<string> tags = quesion.Tag.Split('-', StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string tag in tags)
            {
                QuestionTag newTag = new QuestionTag()
                {
                    Tag = tag,
                    QuestionId = newQuestion.Id
                   
                };

                await _questionRepository.CreateQuestionTagAsync(newTag);
            }
            await _questionRepository.SavechangeAsync();

        }

        public async Task<QuestionVM> GetQuestionServiceAsync(int id)
        {
            Question question = await _questionRepository.GetQuestionAsync(id);

            return new QuestionVM()
            {
                Id = question.Id,
                Title =question.Title,
                Text = question.Text,
                CreateDate = question.CreateDate,
                Visit=question.Visit,
         
            };
        }

        public async Task<IEnumerable<QuestionVM>> GetQuestionsServiceAsync()
        {
            IEnumerable<Question> questionList = await _questionRepository.GetQuestionsAsync();


            return questionList.Select(q => new QuestionVM()
            {
                Id = q.Id,
                Title = q.Title,
                User=new ViewModels.User.UserVM() { UserName=q.User?.UserName},
                Answers=q.Answers.Select(a=> new AnswerVM()
                {
                    CreateDate=a.CreateDate,
                    User=new ViewModels.User.UserVM() { UserName=a.User?.UserName}
                }),
                QuestionTags=q.QuestionTags.Select(a=>new QuestionTagVM()
                {
                    Tag=a.Tag,
                })
            }).ToList();
        }
    }
}
