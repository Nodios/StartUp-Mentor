using StartUpMentor.Service.Common;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StartUpMentor.Common.Filters;
using System.Net;
using StartUpMentor.Model.Common;
using StartUpMentor.UI.Models;
using StartUpMentor.Model;
using System.IO;
using StartUpMentor.UI.Models.Question;
using PagedList;

namespace StartUpMentor.UI.Controllers
{
	public class QuestionController : Controller
    {
        protected IQuestionService Service { get; private set; }
        protected IFieldService FieldService { get; private set; }

        public QuestionController(IQuestionService service, IFieldService fieldService)
        {
            Service = service;
            FieldService = fieldService;
        }

        public async Task<ActionResult> Index(Guid fieldId, string searchString, string currentFilter, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                //ViewBag.FieldId = fieldId;
                QuestionIndexViewModel qivm = new QuestionIndexViewModel();
                qivm.FieldId = fieldId;
                var questionsFromField = await Service.GetRangeAsync(fieldId, new GenericFilter(searchString, pageNumber, pageSize));
                qivm.QuestionList = questionsFromField.ToPagedList(pageNumber, pageSize);
                return View(qivm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<ActionResult> Details(Guid id)
        //{
        //    try
        //    {
        //        if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //        IQuestion question = await Service.GetAsync(id);

        //        if (question == null)
        //            return HttpNotFound();

        //        return View(question);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public ActionResult NewQuestion(Guid fieldId)
        {
            QuestionAddViewModel qavm = new QuestionAddViewModel();
            qavm.FieldId = fieldId;

            return View(qavm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewQuestion(Guid fieldId, QuestionViewModel qvm, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string[] validFileTypes = { "avi", "mpeg", "mp4","MP4","webm" };
                        var fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
                        var contentLenght = file.ContentLength;
                        var contentType = file.ContentType;
                        bool isValidFile = false;
                        var filePath = Path.Combine(Server.MapPath("~/Uploads/Questions"), fileName);
                        string ext = Path.GetExtension(filePath);

                        for(int i = 0; i<validFileTypes.Length; i++)
                        {
                            if(ext == "." + validFileTypes[i])
                            {
                                isValidFile = true;
                                break;
                            }
                        }

                        if (!isValidFile)
                        {
                            //return Content("<script language='javascript' type='text/javascript'>alert('Error, wrong file type');</script>");
                            ViewBag.ErrorType = "Not video file. Please upload video files only";
                            return RedirectToAction("NewQuestion", new { fieldId = fieldId });
                        }
                        else
                        {
                            file.SaveAs(filePath);

                            qvm.Date = DateTime.Now;
                            qvm.FieldId = fieldId;
                            //Save video path to database
                            qvm.VideoPath = filePath;
                            await Service.AddAsync(AutoMapper.Mapper.Map<Question>(qvm));

                            return RedirectToAction("Index", new { fieldId = qvm.FieldId });
                        }
                    }
                }

                return View(qvm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            IQuestion question = await Service.GetAsync(id);

            if (question == null)
                return HttpNotFound();

            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuestionViewModel qvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Service.UpdateAsync(AutoMapper.Mapper.Map<Question>(qvm));
                    return RedirectToAction("Index", new { fieldId = qvm.FieldId});
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var questionToDelete = await Service.GetAsync(id);

            if (questionToDelete == null)
                return HttpNotFound();

            return View(questionToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteQuestion(Guid id)
        {
            var questionToDelete = await Service.GetAsync(id);

            await Service.DeleteAsync(id);
            return RedirectToAction("Index", new { fieldId = questionToDelete.FieldId});
        }
    }
}