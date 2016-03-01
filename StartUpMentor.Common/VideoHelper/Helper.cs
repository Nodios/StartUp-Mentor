//using System;
//using System.Web;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Web.UI;

//namespace StartUpMentor.Common.VideoHelper
//{
//    public class VideoHelper
//    {
//        public void GetVideoStream(string path, string contentType)
//        {
//            HttpContext.Response.AddHeader("Content-Type", contentType);
//            RangeDownload(path, HttpContext);
//        }

//        private void RangeDownload(string fullPath, HttpContext context)
//        {
//            long size, start, end, length, fp = 0;
//            using(StreamReader reader = new StreamReader(fullPath))
//            {
//                size = reader.BaseStream.Length;
//                start = 0;
//                end = size - 1;
//                length = size;

//                context.Response.AddHeader("Accept-Ranges", "0-" + size);

//                if (!String.IsNullOrEmpty(context.Request.ServerVariables["HTTP-RANGE"]))
//                {
//                    long anotherStart = start;
//                    long anotherEnd = end;
//                    string[] arr_split = context.Request.ServerVariables["HTTP-RANGE"].Split(new char[] { Convert.ToChar("=") });
//                    string range = arr_split[1];

//                    if(range.IndexOf(",") > -1)
//                    {
//                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
//                        throw new HttpException(416, "Requested Range Not Satisfiable");
//                    }

//                    if (range.StartsWith("-"))
//                    {
//                        anotherStart = size - Convert.ToInt64(range.Substring(1));
//                    }
//                    else
//                    {
//                        arr_split = range.Split(new char[] { Convert.ToChar("-") });
//                        anotherStart = Convert.ToInt64(arr_split[0]);
//                        long temp = 0;
//                        anotherEnd = (arr_split.Length > 1 && Int64.TryParse(arr_split[1].ToString(), out temp)) ? Convert.ToInt64(arr_split[1]) : size;
//                    }

//                    anotherEnd = (anotherEnd > end) ? end : anotherEnd;
//                    if(anotherStart > anotherEnd || anotherStart > size-1 || anotherEnd >= size)
//                    {
//                        context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
//                        throw new HttpException(416, "Requested Range Not Satisfiable");
//                    }
//                    start = anotherStart;
//                    end = anotherEnd;

//                    length = end - start + 1;
//                    fp = reader.BaseStream.Seek(start, SeekOrigin.Begin);
//                    context.Response.StatusCode = 206;
//                }
//            }

//            context.Response.AddHeader("Content-Range", "bytes " + start + "-" + end + "/" + size);
//            context.Response.AddHeader("Content-Length", length.ToString());
//            context.Response.WriteFile(fullPath, fp, length);
//            context.Response.End();
//        }
//    }
//}