using System;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace SriHashTest.Services
{
    public static class ScriptsExtensionMethods
    {
        public static IHtmlString RenderSecureScript(this HtmlHelper helper, string url)
        {
            var virtualPath = (url.StartsWith("~/")) ? url : $"~/{url}";
            var absPath = VirtualPathUtility.ToAbsolute(virtualPath);

            var filePath = HttpContext.Current.Server.MapPath(virtualPath);
            var hash = string.Empty;

            using (var sha384Hash = SHA384.Create())
            {
                hash = Convert.ToBase64String(sha384Hash.ComputeHash(File.ReadAllBytes(filePath)));
            }

            return new HtmlString($"<script src=\"{absPath}\" integrity=\"sha384-{hash}\" crossorigin=\"anonymous\"></script>");
        }
    }
}