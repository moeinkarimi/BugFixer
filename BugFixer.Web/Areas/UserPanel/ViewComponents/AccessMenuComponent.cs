using BugFixer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BugFixer.Web.Areas.UserPanel.ViewComponents
{
    public class AccessMenuComponent:ViewComponent
    {
        private readonly IQuestionService _questionService;
        public AccessMenuComponent(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var qaCounts = await _questionService.GetQACountsServiceAsync(userId);
            ViewBag.qaCounts = qaCounts;
            return View();
        }
    }
}
