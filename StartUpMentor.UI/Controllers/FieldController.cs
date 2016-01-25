using StartUpMentor.Common.Filters;
using StartUpMentor.Service.Common;
using StartUpMentor.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PagedList;
using StartUpMentor.UI.Models;
using StartUpMentor.Model;
using System.Net;
using StartUpMentor.Model.Common;

namespace StartUpMentor.UI.Controllers
{
    public class FieldController : Controller
    {
        protected IFieldService Service { get; private set; }

        public FieldController(IFieldService service)
        {
            Service = service;
        }

        // GET: Field
        public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        {
            var fields = await Service.GetRangeAsync(new GenericFilter(searchString, pageNumber, pageSize));
            return View(fields);
        }

        // GET: Field/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Field/Create
        [HttpPost]
        public async Task<ActionResult> Create(FieldViewModel fvm)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsnyc(AutoMapper.Mapper.Map<Field>(fvm));

                return RedirectToAction("Index");
            }
            return View(fvm);
        }

        // GET: Field/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            IField field = await Service.GetAsync(id);
            if (field == null)
                return HttpNotFound();

            return View(field);
        }

        // POST: Field/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(FieldViewModel fvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Service.UpdateAsync(AutoMapper.Mapper.Map<Field>(fvm));
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var fieldToDelete = await Service.GetAsync(id);
            if (fieldToDelete == null)
            {
                return HttpNotFound();
            }

            return View(fieldToDelete);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteField(Guid id)
        {
            await Service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
