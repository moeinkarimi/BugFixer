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
        public static void UserServices(IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserService, UserService>();

            service.AddScoped<IAccountService, AccountService>();

            service.AddScoped<IViewRenderService, RenderViewToString>();
        }
    }
}
