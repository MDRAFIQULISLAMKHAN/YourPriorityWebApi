using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using YourPriorityWebApi.Models;

namespace YourPriorityWebApi.Controllers
{
    public class EmailController : Controller
    {

        public string Get()
        {
            return "Welcome to Web Api";
        }

        public List<string> Get(int ID)
        {
            return new List<string>
            {
                "Data1",
                "Data2"
            };
        }
        
        public string PostEmail(EmailBody email)
        {

            try
            {
                string body = string.Empty;
                /*var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Views/Email_Templates/adminestrator-email.cshtml");
                using (StreamReader reader = new StreamReader(mappedPath))
                {
                    body = reader.ReadToEnd();
                }*/
                body = "{Name}<br>{Email}<br>{Phone}<br>{Regarding}<br>{Office}<br>{Refference}<br>{Message}";
                body = body.Replace("{Name}", email.Name);
                body = body.Replace("{Email}", email.Email);
                body = body.Replace("{Phone}", email.Phone);
                body = body.Replace("{Regarding}", email.Regarding);
                body = body.Replace("{Office}", email.Office);
                body = body.Replace("{Refference}", email.Refference);
                body = body.Replace("{Message}", email.Message);

                using (MailMessage mailMessage = new MailMessage())
                {

                    MailMessage _mailmsg = new MailMessage();

                    _mailmsg.IsBodyHtml = true;

                    _mailmsg.From = new MailAddress("test.sgff@gmail.com");

                    _mailmsg.To.Add("sagorkhan.fts@gmail.com");

                    _mailmsg.Subject = "Hello";

                    _mailmsg.Body = body;

                    SmtpClient _smtp = new SmtpClient();

                    _smtp.Host = "smtp.gmail.com";

                    _smtp.Port = 587;

                    _smtp.EnableSsl = true;

                    NetworkCredential _network = new NetworkCredential("test.sgff@gmail.com", "testingg");
                    _smtp.Credentials = _network;

                    _smtp.Send(_mailmsg);
                }

                //var message = Request.CreateResponse(HttpStatusCode.Created);

                return "Successfully sent";

            }
            catch (Exception ex)
            {
                /*return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);*/
                return "Request Denied";
            }
        }

        [AllowCrossSiteJson]
        [System.Web.Mvc.HttpPost]
        public JsonResult Post(string jsons)
        {

            var test = JsonConvert.DeserializeObject<EmailBody>(jsons);
            var resEmail = PostEmail(test);
            return Json(resEmail, JsonRequestBehavior.AllowGet);
        }
    }
}
