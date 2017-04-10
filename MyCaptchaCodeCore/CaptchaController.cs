using System.Web.Mvc;

namespace MyCaptchaCodeCore
{
    public class CaptchaController : Controller
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCaptchaCode()
        {
            CaptchaCode code = new CaptchaCode();
            if (Session["CaptchaCode"] == null)
            {
                Session.Add("CaptchaCode", code.Text);
            }
            else
            {
                Session["CaptchaCode"] = code.Text;
            }
            return File(code.RenderImage(), @"image/jpeg");
        }
    }
}