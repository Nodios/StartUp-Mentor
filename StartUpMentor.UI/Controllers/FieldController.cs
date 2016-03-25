using StartUpMentor.Common.Filters;
using StartUpMentor.Service.Common;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using StartUpMentor.UI.Models;
using StartUpMentor.Model;
using System.Net;
using StartUpMentor.Model.Common;
using System.Web;
using System.IO;

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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FieldViewModel fvm, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string[] validFileTypes = { "jpg", "jpeg", "png", "bmp" };
                        var imageName = Path.GetFileName(file.FileName);
                        bool isValidFile = false;
                        var imagePath = Path.Combine(Server.MapPath("~/Uploads/FieldImages"), imageName);
                        string ext = Path.GetExtension(imagePath);

                        for (int i = 0; i < validFileTypes.Length; i++)
                        {
                            if (ext == "." + validFileTypes[i])
                            {
                                isValidFile = true;
                                break;
                            }
                        }

                        if (!isValidFile)
                        {
                            //return Content("<script language='javascript' type='text/javascript'>alert('Error, wrong image type');</script>");
                            ViewBag.ErrorType = "Image format not supported. Try jpg, png, bmp.";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            file.SaveAs(imagePath);

                            fvm.ImagePath = imagePath;

                            await Service.AddAsnyc(AutoMapper.Mapper.Map<Field>(fvm));

                            return RedirectToAction("Index");
                        }
                    }
                }
                return View(fvm);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ActionResult> Edit(Guid id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            IField field = await Service.GetAsync(id);
            if (field == null)
                return HttpNotFound();

            return View(field);
        }

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
