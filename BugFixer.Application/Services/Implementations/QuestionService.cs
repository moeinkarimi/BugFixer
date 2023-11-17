using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Questions;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Questions;

namespace BugFixer.Application.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }



        #region Question Methods
        public async Task CreateQuestionServiceAsync(CreateQuestionVM quesion, int userId)
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
                Title = question.Title,
                Text = question.Text,
                CreateDate = question.CreateDate,
                Visit = question.Visit,

                QuestionTags = question.QuestionTags.Select(q => new QuestionTagVM()
                {
                    Tag = q.Tag,
                }).ToList(),

                User = question.User,
                Answers = question.Answers,






            };
        }

        public async Task<IEnumerable<QuestionVM>> GetQuestionsServiceAsync()
        {
            IEnumerable<Question> questionList = await _questionRepository.GetQuestionsAsync();


            return questionList.Select(q => new QuestionVM()
            {
                Id = q.Id,
                Title = q.Title,
                User = q.User,
                Answers = q.Answers,
                QuestionTags = q.QuestionTags.Select(a => new QuestionTagVM()
                {
                    Tag = a.Tag,
                })
            }).ToList();
        }





        public async Task UpdteQuestionVisitService(int questionId)
        {
            Question question = await _questionRepository.GetQuestionAsync(questionId);

            question.Visit += 1;
            _questionRepository.UpdateQuestion(question);
            await _questionRepository.SavechangeAsync();
        }

        public async Task<QACounts> GetQACountsServiceAsync(int userId)
        {
            var qCounts = await _questionRepository.GetUserQuestionsCountAsync(userId);
            var aCounts = await _questionRepository.GetUserAnswersCountAsync(userId);

            return new QACounts
            {
                QuestionsCount = qCounts != null ? qCounts : 0,
                AnswersCount = aCounts != null ? aCounts : 0
            };
        }
        #endregion


        #region Answer Methods
        public async Task CreateAnswerServiceAsync(string answerText, int questionId, int userId)
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
        public async Task<FilterQuestionAswersVM> QuestionAnswersFilter(FilterQuestionAswersVM filter, int questionId)
        {
            IQueryable<Answer> answers = _questionRepository.QuestionAnswersQueryable(questionId);

            IQueryable<ShowQuestionAnswerVM> result = answers.Select(a => new ShowQuestionAnswerVM()
            {
                AnswerId = a.Id,
                Text = a.Text,
                CreateDate = a.CreateDate,
                SenderName = a.User.UserName,
                SenderAvatar = a.User.Avatar,
                NumberOfAnswersSender = a.User.Answers.Count,
                NumberOfQuestionSender = a.User.Questions.Count,
                SenderId = a.UserId
            }).AsQueryable();

            switch (filter.OrderType)
            {
                case "new":

                    result = result.OrderByDescending(a => a.CreateDate);
                    break;

                case "old":

                    result = result.OrderBy(a => a.CreateDate);
                    break;
                default:

                    break;




            }
            await filter.Paging(result);
            return filter;




        }
        public async Task UpdateAnswerService(UpdateAnswerVM updateAnswer)
        {
            Answer answer = await _questionRepository.GetAnswerById(updateAnswer.AnswerId);

            answer.Text = updateAnswer.Text;
            _questionRepository.UpdateAnswer(answer);
            await _questionRepository.SavechangeAsync();
        }

        public async Task<UpdateAnswerVM> GetAnswerForUpdateServiceAsync(int answerId)
        {
            Answer getAnswer=await _questionRepository.GetAnswerById(answerId);

            return new UpdateAnswerVM()
            {
                AnswerId=getAnswer.Id,
                Text=getAnswer.Text,
            };
        }

        #endregion
    }
}
