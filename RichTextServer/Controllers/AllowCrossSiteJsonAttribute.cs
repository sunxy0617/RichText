using System.Web.Mvc;

namespace RichTextServer.Controllers
{
    /// <summary>
    /// 在webapi函数上加"[AllowCrossSite]"可以跨域调用
    /// </summary>
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }
    }
}