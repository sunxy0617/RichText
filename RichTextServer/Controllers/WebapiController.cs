using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace RichTextServer.Controllers
{
    public class WebapiController : MyGetController
    {
        // GET: Webpai
        public ActionResult Index()
        {
            return View();
        }
        
        public string UploadImg2()
        {
            var files = GetRequestFiles(Request);


            return  "[{'url':'//www.iceui.net/www/iceui/upload/iceEditor/20200509/1589014279.png','name':'book.png','error':0}]";

        }

        [AllowCrossSiteJson]
        [ValidateInput(false)]
        public JsonResult UploadImg()
        {
            var files = GetRequestFiles(Request);
            var imgsPath = Server.MapPath("/Resources/RichText/img/");
            if (!Directory.Exists(imgsPath))
            {
                Directory.CreateDirectory(imgsPath);
            }

            var url = Request.Url;
            var baseUrl = $"{url.Scheme}://{url.Host}:{url.Port}";
            var imgsUrl = new string[files.Count];
            for (var i = 0; i < files.Count; i++)
            {
                var file = files[i];
                var fileName = DateTime.Now.ToFileTime() + "_" + file.FileName;
                var imgPath = imgsPath + fileName;
                file.SaveAs(imgPath);
                imgsUrl[i] = baseUrl + "/Resources/RichText/img/" + fileName;
            }
            return Json(new
            {
                errno = 0,
                data = imgsUrl
            });
        }

        private Dictionary<int, HttpPostedFileBase> GetRequestFiles(HttpRequestBase request)
        {
            var sArray = new Dictionary<int, HttpPostedFileBase>();
            var coll = request.Files;
            //string[] requestItem = coll.AllKeys;
            for (var i = 0; i < coll.Count; i++)
            {
                var file = request.Files[i];
                sArray.Add(i,file);
            }
            return sArray;

        }
    }
}