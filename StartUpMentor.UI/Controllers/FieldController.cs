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

        // GET: Field/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Field/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Field/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Field/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Field/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Field/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Field/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
