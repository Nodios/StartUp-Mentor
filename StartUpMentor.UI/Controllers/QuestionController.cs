using StartUpMentor.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using StartUpMentor.Common.Filters;
using System.Net;
using StartUpMentor.Model.Common;
using StartUpMentor.UI.Models;
using StartUpMentor.Model;
using System.IO;

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
                ViewBag.FieldId = fieldId;
                var questionsFromField = await Service.GetRangeAsync(fieldId, new GenericFilter(searchString, pageNumber, pageSize));
                return View(questionsFromField);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                IQuestion question = await Service.GetAsync(id);

                if (question == null)
                    return HttpNotFound();

                return View(question);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult NewQuestion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewQuestion(QuestionViewModel qvm, Guid fieldId)
        {
            if (ModelState.IsValid)
            {
                qvm.Date = DateTime.Now;
                qvm.FieldId = fieldId;
                //OVDJE TREBA BITI VIDEO UPLOAD
                await Service.AddAsync(AutoMapper.Mapper.Map<Question>(qvm));

                return RedirectToAction("Index", new { fieldId = qvm.FieldId});
            }
            return View(qvm);
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
    }
}