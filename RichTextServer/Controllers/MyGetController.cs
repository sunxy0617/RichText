using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RichTextServer.Controllers
{
    /// <summary>
    /// 支持Get
    /// </summary>
    public class MyGetController : Controller
    {
        protected new JsonResult Json(object data)
        {
            return Json(data, null, null, JsonRequestBehavior.AllowGet);
        }
    }
}