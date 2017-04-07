using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyCaptchaCodeCore
{
    public static class CaptchaHelper
    {
        private static MvcHtmlString GetCaptchaCode(this HtmlHelper helper, string actionName, string controllerName, CaptchaOptions options)
        {
            if (options == null)
                options = new CaptchaOptions();
            var image = new CaptchaCode(options);
            HttpContext.Current.Session.Add(
                "CaptchaCode",
                image);
            var url = new UrlHelper(helper.ViewContext.RequestContext);
            var sb = new StringBuilder(1500);
            const string copyrightText = "\r\n<!-- MyCaptcha 1.0 @Leiyang -->\r\n";
            sb.Append(copyrightText);
            sb.Append(CreateImgTag(options));
            sb.Append(copyrightText);
            return MvcHtmlString.Create(sb.ToString());
        }

        static string CreateImgTag(CaptchaOptions options)
        {
            var sb = new StringBuilder("<a href=\"javascript:void(0)\"><img src=\"");
            sb.Append("/Captcha/GetCaptchaCode");
            sb.Append("\" alt=\"MvcCaptcha\" title=\"刷新图片\" width=\"");
            sb.Append(options.Width);
            sb.Append("\" height=\"");
            sb.Append(options.Height);
            sb.Append("\" border=\"0\" onclick=\"this.src = '/Captcha/GetCaptchaCode?d=' + Math.random(); \"/></a>");
            return sb.ToString();
        }

        public static MvcHtmlString GetCaptchaCode(this HtmlHelper helper)
        {
            return GetCaptchaCode(helper, new CaptchaOptions());
        }

        public static MvcHtmlString GetCaptchaCode(this HtmlHelper helper, CaptchaOptions options)
        {
            return GetCaptchaCode(helper, "MvcCaptchaImage", "_MvcCaptcha", options);
        }
    }
}
