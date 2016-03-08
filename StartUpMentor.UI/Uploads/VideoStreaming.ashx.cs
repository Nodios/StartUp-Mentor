using System;
using System.IO;
using System.Web;

namespace StartUpMentor.UI.Uploads
{
	/// <summary>
	/// Summary description for VideoStreaming
	/// </summary>
	public class VideoStreaming : IHttpHandler
    {
        private void RangeDownload(string fullPath, HttpContext context)
        {
            long size, start, end, length, fp = 0;
            using (StreamReader reader = new StreamReader(fullPath))
            {
                size = reader.BaseStream.Length;
                start = 0;
                end = size - 1;
                length = size;

                context.Response.AddHeader("Accept-Ranges", "0-" + size);

                if (!String.IsNullOrEmpty(context.Request.ServerVariables["HTTP-RANGE"]))
                {
                    long anotherStart = start;
                    long anotherEnd = end;
                    string[] arr_split = context.Request.ServerVariables["HTTP-RANGE"].Split(new char[] { Convert.ToChar("=") });
                    string range = arr_split[1];

                    if (range.IndexOf(",") > -1)
                    {
                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
                        throw new HttpException(416, "Requested Range Not Satisfiable");
                    }

                    if (range.StartsWith("-"))
                    {
                        anotherStart = size - Convert.ToInt64(range.Substring(1));
                    }
                    else
                    {
                        arr_split = range.Split(new char[] { Convert.ToChar("-") });
                        anotherStart = Convert.ToInt64(arr_split[0]);
                        long temp = 0;
                        anotherEnd = (arr_split.Length > 1 && Int64.TryParse(arr_split[1].ToString(), out temp)) ? Convert.ToInt64(arr_split[1]) : size;
                    }

                    anotherEnd = (anotherEnd > end) ? end : anotherEnd;
                    if (anotherStart > anotherEnd || anotherStart > size - 1 || anotherEnd >= size)
                    {
                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
                        throw new HttpException(416, "Requested Range Not Satisfiable");
                    }
                    start = anotherStart;
                    end = anotherEnd;

                    length = end - start + 1;
                    fp = reader.BaseStream.Seek(start, SeekOrigin.Begin);
                    context.Response.StatusCode = 206;
                }
            }

            context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
            context.Response.AddHeader("Content-Length", length.ToString());
            context.Response.WriteFile(fullPath, fp, length);
            context.Response.End();
        }

        public void ProcessRequest(HttpContext context)
        {
            string filename = context.Request["source"];
            string mimetype = "video/mp4";
            string fullpath = context.Server.MapPath("~/Uploads/Questions/" + filename);
            if (File.Exists(fullpath))
            {
                context.Response.ContentType = mimetype;
                if (!String.IsNullOrEmpty(context.Request.ServerVariables["HTTP_RANGE"]))
                {
                    RangeDownload(fullpath, context);
                }
                else
                {
                    long fileLength = File.OpenRead(fullpath).Length;
                    context.Response.AddHeader("Content-Length", fileLength.ToString());
                    context.Response.WriteFile(fullpath);
                }
            }
        else
        {
                throw new HttpException(404, "Video Not Found Path:" + fullpath);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}