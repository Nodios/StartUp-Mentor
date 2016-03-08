using PagedList;
using StartUpMentor.Common.Filters;
using StartUpMentor.Model;
using StartUpMentor.Model.Common;
using StartUpMentor.Service.Common;
using StartUpMentor.UI.Models;
using StartUpMentor.UI.Models.Answer;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
//using StartUpMentor.Common.VideoHelper;

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
            AnswerAddViewModel aavm = new AnswerAddViewModel();
            aavm.QuestionId = questionId;

            return View(aavm);
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
                        string[] validFileTypes = { "avi", "mpeg", "mp4", "MP4","webm" };
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

                            return RedirectToAction("Index", new { questionId = avm.QuestionId });
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

		#region Video stream
		public void GetVideoStream(string fileName, string contentType)
		{
			var path = Path.Combine(Server.MapPath("~/Uploads/Questions/"), fileName);
			HttpContext.Response.AddHeader("Content-Type", contentType);
			RangeDownload(path, HttpContext.ApplicationInstance.Context);
		}

		//http://blogs.visigo.com/chriscoulson/easy-handling-of-http-range-requests-in-asp-net/
		private void RangeDownload(string fullpath, HttpContext context)
		{
			long size, start, end, length, fp = 0;
			using (StreamReader reader = new StreamReader(fullpath))
			{

				size = reader.BaseStream.Length;
				start = 0;
				end = size - 1;
				length = size;
				// Now that we've gotten so far without errors we send the accept range header
				/* At the moment we only support single ranges.
				 * Multiple ranges requires some more work to ensure it works correctly
				 * and comply with the spesifications: http://www.w3.org/Protocols/rfc2616/rfc2616-sec19.html#sec19.2
				 *
				 * Multirange support annouces itself with:
				 * header('Accept-Ranges: bytes');
				 *
				 * Multirange content must be sent with multipart/byteranges mediatype,
				 * (mediatype = mimetype)
				 * as well as a boundry header to indicate the various chunks of data.
				 */
				context.Response.AddHeader("Accept-Ranges", "0-" + size);
				// header('Accept-Ranges: bytes');
				// multipart/byteranges
				// http://www.w3.org/Protocols/rfc2616/rfc2616-sec19.html#sec19.2

				if (!String.IsNullOrEmpty(context.Request.ServerVariables["HTTP_RANGE"]))
				{
					long anotherStart = start;
					long anotherEnd = end;
					string[] arr_split = context.Request.ServerVariables["HTTP_RANGE"].Split(new char[] { Convert.ToChar("=") });
					string range = arr_split[1];

					// Make sure the client hasn't sent us a multibyte range
					if (range.IndexOf(",") > -1)
					{
						// (?) Shoud this be issued here, or should the first
						// range be used? Or should the header be ignored and
						// we output the whole content?
						context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
						throw new HttpException(416, "Requested Range Not Satisfiable");

					}

					// If the range starts with an '-' we start from the beginning
					// If not, we forward the file pointer
					// And make sure to get the end byte if spesified
					if (range.StartsWith("-"))
					{
						// The n-number of the last bytes is requested
						anotherStart = size - Convert.ToInt64(range.Substring(1));
					}
					else
					{
						arr_split = range.Split(new char[] { Convert.ToChar("-") });
						anotherStart = Convert.ToInt64(arr_split[0]);
						long temp = 0;
						anotherEnd = (arr_split.Length > 1 && Int64.TryParse(arr_split[1].ToString(), out temp)) ? Convert.ToInt64(arr_split[1]) : size;
					}
					/* Check the range and make sure it's treated according to the specs.
					 * http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html
					 */
					// End bytes can not be larger than $end.
					anotherEnd = (anotherEnd > end) ? end : anotherEnd;
					// Validate the requested range and return an error if it's not correct.
					if (anotherStart > anotherEnd || anotherStart > size - 1 || anotherEnd >= size)
					{

						context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
						throw new HttpException(416, "Requested Range Not Satisfiable");
					}
					start = anotherStart;
					end = anotherEnd;

					length = end - start + 1; // Calculate new content length
					fp = reader.BaseStream.Seek(start, SeekOrigin.Begin);
					context.Response.StatusCode = 206;
				}
			}
			// Notify the client the byte range we'll be outputting
			context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
			context.Response.AddHeader("Content-Length", length.ToString());
			// Start buffered download
			context.Response.WriteFile(fullpath, fp, length);
			context.Response.End();

		}
		#endregion

	}
}