using PagedList;
using StartUpMentor.Common.Filters;
using StartUpMentor.Model;
using StartUpMentor.Model.Common;
using StartUpMentor.Service.Common;
using StartUpMentor.UI.Models;
using StartUpMentor.UI.Models.Answer;
using System;
using System.Collections.Generic;
using System.IO;
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
                //ViewBag.QuestionId = questionId;
                AnswerIndexViewModel aivm = new AnswerIndexViewModel();
                aivm.QuestionId = questionId;
                aivm.Question = await QuestionService.GetAsync(questionId);

                var answersFromQuestion = await Service.GetRangeAsync(questionId, new GenericFilter(searchString, pageNumber, pageSize));
                aivm.AnswerList = answersFromQuestion.ToPagedList(pageNumber, pageSize);
                return View(aivm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult NewAnswer(Guid questionId)
        {
            AnswerIndexViewModel aivm = new AnswerIndexViewModel();
            aivm.QuestionId = questionId;

            return View(aivm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewAnswer(Guid questionId, AnswerViewModel avm, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string[] validFileTypes = { "avi", "mpeg", "mp4", "MP4" };
                        var fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
                        var contentLenght = file.ContentLength;
                        var contentType = file.ContentType;
                        bool isValidFile = false;
                        var filePath = Path.Combine(Server.MapPath("~/Uploads/Answers"), fileName);
                        string ext = Path.GetExtension(filePath);

                        for (int i = 0; i < validFileTypes.Length; i++)
                        {
                            if (ext == "." + validFileTypes[i])
                            {
                                isValidFile = true;
                                break;
                            }
                        }

                        //var filePath = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);

                        if (!isValidFile)
                        {
                            //return Content("<script language='javascript' type='text/javascript'>alert('Error, wrong file type');</script>");
                            ViewBag.ErrorType = "Not video file. Please upload video files only";
                            return RedirectToAction("NewAnswer", new { questionId = questionId });
                        }
                        else
                        {
                            file.SaveAs(filePath);

                            avm.Date = DateTime.Now;
                            avm.QuestionId = questionId;
                            //Save video path to database
                            avm.VideoPath = filePath;
                            await Service.AddAsync(AutoMapper.Mapper.Map<Answer>(avm));

                            return RedirectToAction("Index", new { fieldId = avm.QuestionId });
                        }

                        //if (ModelState.IsValid)
                        //{
                        //    avm.Date = DateTime.Now;
                        //    avm.DateLastEdited = avm.Date;
                        //    avm.QuestionId = questionId;

                        //    await Service.AddAsync(AutoMapper.Mapper.Map<Answer>(avm));
                        //    return RedirectToAction("Index", new { questionId = avm.QuestionId});
                        //}
                        //return View(avm);
                    }
                }

                return View(avm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            IAnswer answer = await Service.GetAsync(id);

            if (answer == null)
                return HttpNotFound();

            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnswerViewModel avm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    avm.DateLastEdited = DateTime.Now;

                    await Service.UpdateAsync(AutoMapper.Mapper.Map<Answer>(avm));
                    return RedirectToAction("Index", new { questionId = avm.QuestionId });
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}