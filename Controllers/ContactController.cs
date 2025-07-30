using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FlyingWonder.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendData(string name, string email, string phone, string message)
        {
            string emailBody = @"<html xmlns='http://www.w3.org/1999/xhtml'>
                                    <head>
                                        <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
                                        <title></title>
                                        <style></style>
                                    </head>
                                    <body>
                                        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable'>
                                            <tr>
                                                <td align='center' valign='top'>
                                                    <table border='0' cellpadding='20' cellspacing='0' width='600' id='emailContainer'>
                                                        <tr><td align='center' valign='top'> Name :" + name +
                                                       "</td><tr><td align='center' valign='top'>Email :" + email +
                                                       "</td><tr><td align='center' valign='top'>Phone :" + phone +
                                                       "</td><tr><td align='center' valign='top'>Message :" + message +
                                                            @"</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </body>
                                </html>";
            this.SendEmailNew(emailBody);
            return Json("Success");
        }

        public string SendEmailNew(string emailBody = "", string toAddress = "veeruprabhu2006@gmail.com", string emailTitle = "Query from flying wonder")
        {
            string senderID = "flyingwonder2020@gmail.com", senderPassword = "Flyhigh@2020";
            string result = string.Empty;
            try
            {
                string host = "";
                int port = 0;
                bool ssl = true;
                bool creds = true;

                host = "smtp.gmail.com";
                port = 587;
                ssl = true;
                creds = true;
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(senderID, toAddress, emailTitle, emailBody);
                message.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                message.IsBodyHtml = true;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.UseDefaultCredentials = false;
                smtp.Host = host; // smtp server address here…
                smtp.Port = port;
                smtp.EnableSsl = ssl;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = creds ? new System.Net.NetworkCredential(senderID, senderPassword) : CredentialCache.DefaultNetworkCredentials;
                smtp.Timeout = 30000;
                smtp.Send(message);
                result = "success";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}