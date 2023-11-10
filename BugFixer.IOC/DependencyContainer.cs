using BugFixer.Application.Services.Implementations;
using BugFixer.Application.Services.Interfaces;
using BugFixer.Data.Repository;
using BugFixer.Domain.Interfaces;
using EShop.Application.Convertors;
using Microsoft.Extensions.DependencyInjection;


namespace BugFixer.IOC
{
    public class DependencyContainer
    {
        #region User Services
        public static void UserServices(IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserService, UserService>();

            service.AddScoped<IAccountService, AccountService>();

            service.AddScoped<IViewRenderService, RenderViewToString>();
        }
        #endregion


        #region RoleServices
        public static void RoleServices(IServiceCollection service)
        {
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IRoleService, RoleService>();
        }
        #endregion

        #region Question Services
        public static void QuestionServices(IServiceCollection service)
        {
            service.AddScoped<IQuestionRepository, QuestionRepository>();
            service.AddScoped<IQuestionService, QuestionService>();
        }

        public static void AnswerServices(IServiceCollection service)
        {
            service.AddScoped<IAnswerRepository, AnswerRepository>();
            service.AddScoped<IAnswerService, AnswerService>();
        }
        #endregion

    }
}
