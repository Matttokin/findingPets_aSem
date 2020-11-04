using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;

namespace findingPets.Controllers
{
    public class sendImgProfileController : ApiController
    {
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    Random rd = new Random();
                    String now = DateTime.Now.ToString().Replace(' ', '_').Replace('.', '_').Replace(':', '_') + rd.Next(100);
                    var filePath = HttpContext.Current.Server.MapPath("~/uploadImg/" + now+postedFile.FileName);
                    Console.WriteLine(DateTime.Today.ToString());
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                    result = Request.CreateResponse("/uploadImg/" + now + postedFile.FileName);
                }
                //result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                
            }
            else
            {
                result = Request.CreateResponse("-1");
            }
            return result;
        }
    }
}
