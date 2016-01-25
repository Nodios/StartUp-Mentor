using StartUpMentor.Common.Filters;
using StartUpMentor.Model;
using StartUpMentor.Model.Common;
using StartUpMentor.Service.Common;
using StartUpMentor.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StartUpMentor.UI.Controllers
{
    public class AnswerController : Controller
    {
        protected IAnswerService Service { get; private set; }
        protected IQuestionService QuestionService { get; private set; }

        #region Controller
        public AnswerController(IAnswerService service, IQuestionService questionService)
        {
            Service = service;
            QuestionService = questionService;
        }
        #endregion

        public async Task<ActionResult> Index(Guid questionId, string searchString, string currentFilter, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                ViewBag.QuestionId = questionId;
                var answersFromQuestion = await Service.GetRangeAsync(questionId, new GenericFilter(searchString, pageNumber, pageSize));
                return View(answersFromQuestion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult NewAnswer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAnswer(AnswerViewModel avm, Guid questionId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    avm.Date = DateTime.Now;
                    avm.QuestionId = questionId;
                    await Service.AddAsync(AutoMapper.Mapper.Map<Answer>(avm));
                    return RedirectToAction("Index", new { questionId = avm.QuestionId});
                }
                return View(avm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}