using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        // GET: TeacherPanelMessage
        MessageManagerBL mm = new MessageManagerBL(new EfMessageDAL());
        MessageValidator messagevalidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string p = (string)Session["TeacherMail"];
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult Sendbox()
        {
            string p = (string)Session["TeacherMail"];
            var messagelist = mm.GetListSendbox(p);
            return View(new Message()); // Boş bir Message nesnesi geçiriyoruz.
        }

        [HttpPost]
        public ActionResult Sendbox(Message message, string ReceiverMail)
        {
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    return true; // Sertifika doğrulamasını atlar
                };

            MailMessage mailim = new MailMessage();
            mailim.To.Add(ReceiverMail); // Kullanıcıdan alınan alıcı e-posta adresi
            mailim.From = new MailAddress("banuokullari@gmail.com");
            mailim.Subject = "Değerli Velimiz sınav öncesi değerlendirme sonuçları: " + message.Subject;
            mailim.Body = "BANÜ OKULLARI " + message.MessageContent;
            mailim.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("banuokullari@gmail.com", "vsjg fmsg pxho omjs");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mailim);
                TempData["Message"] = "Mailiniz başarıyla gönderildi.";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Mail gönderilemedi. Hata nedeni: " + ex.Message;
            }

            return View();
        }
    }
}
