﻿using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Questions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BugFixer.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        #region Constructor
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        #endregion
        #region Actions
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("submit-question")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost("submit-question")]
        [Authorize]

        public async Task<IActionResult> Create(CreateQuestionVM create)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!ModelState.IsValid)
            {
                return View(create);
            }
            await _questionService.CreateQuestionServiceAsync(create, userId);
            return Redirect("/");
        }






        [HttpGet("show-question/{id}")]
        public async Task<IActionResult> ShowQuestion(int id)
        {
            QuestionVM question = await _questionService.GetQuestionServiceAsync(id);
            return View(question);
        }


        [HttpPost("show-question/{id}")]
        [Authorize]
        public async Task<IActionResult> ShowQuestion(string AnswerText, int QuestionId, int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));


            await _questionService.CreateAnswerServiceAsync(AnswerText, QuestionId, userId);
            return Redirect("/Home/Index");
        }


        #endregion
    }
}
