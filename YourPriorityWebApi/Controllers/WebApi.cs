using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using YourPriorityWebApi.Models;

namespace YourPriorityWebApi.Controllers
{
    public class WebApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}
        
        [HttpGet, HttpPost]
        public HttpResponseMessage MessagePost([FromBody] EmailBody email, HttpRequestMessage request)
        {
            /*//JToken postData = new JToken();
            // Initialization
            HttpResponseMessage response = null;
            EmailBody requestObj = JsonConvert.DeserializeObject<EmailBody>(postData.ToString());
            DataTable responseObj = new DataTable();
            string json = string.Empty;

            json = JsonConvert.SerializeObject(responseObj);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");


            return response;*/

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

                var message = Request.CreateResponse(HttpStatusCode.Created);


            }
            catch (Exception ex)
            {
                var message = Request.CreateResponse(HttpStatusCode.Created);

            }
            HttpResponseMessage response = null;
            string json = string.Empty;
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");


            return response;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}