using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Reports
{
    public class ContentTypeFactory
    {
        private static Dictionary<string, string> contentTypeByFormat = new Dictionary<string, string>();
        private static Dictionary<string, string> contentTypeByExtension = new Dictionary<string, string>();



        static ContentTypeFactory() {
            if (contentTypeByFormat.Count() == 0) {
                contentTypeByFormat.Add("pdf","application/pdf");
                contentTypeByFormat.Add("excel", "application/vnd.ms-excel");
            }

            if (contentTypeByExtension.Count() == 0) {
                contentTypeByExtension.Add("jpg","image/jpeg");
                contentTypeByExtension.Add("jpeg", "image/jpeg");
                contentTypeByExtension.Add("png", "image/png");
                contentTypeByExtension.Add("gif", "image/gif");
                contentTypeByExtension.Add("txt", "text/html");
                contentTypeByExtension.Add("doc", "application/msword");
                contentTypeByExtension.Add("docx", "application/msword");
                contentTypeByExtension.Add("ppt", "application/vnd.ms-powerpoint");
                contentTypeByExtension.Add("pptx", "application/vnd.ms-powerpoint");
                contentTypeByExtension.Add("pdf", "application/pdf");
                contentTypeByExtension.Add("mp3", "audio/mpeg");
                contentTypeByExtension.Add("mp4", "video/mp4");
                contentTypeByExtension.Add("flv", "video/x-flv");
                contentTypeByExtension.Add("wmv", "application/x-ms-wmv");
            }
        }

        public static string CreateByFormat(string format) {
            return contentTypeByFormat[format.ToLower()];
        }

        public static string CreateByExtension(string extension) {
            return contentTypeByExtension[extension.ToLower()];
        }
    }
}