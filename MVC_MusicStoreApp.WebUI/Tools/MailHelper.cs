using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
namespace MVC_MusicStoreApp.WebUI.Tools
{
    public class MailHelper
    {
        public static bool AktivasyonKoduGonder(string username,string mail,string confirmationToken)
        {
            bool result=false;
            MailMessage msg = new MailMessage();
            msg.To.Add(mail);
            msg.Subject = "Aktivasyon onay maili";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<!DOCTYPE html><html><head><title>Activasyon Maili</title></head><body><h3>Sayın {0} sitemize hoşgeldiniz.</h3> <p>Activasyonu Gerçekleştirmek için <a href='http://localhost:39816/Account/ActivationUser/{1}'>tıklayınız...</a></p></body></html>",username, confirmationToken);
            msg.From =new MailAddress("yms3120@outlook.com", "MVC_MusicStoreApp");

            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
            smtp.EnableSsl = true;
            NetworkCredential cred = new NetworkCredential("yms3120@outlook.com","123456Ym");
            smtp.Credentials = cred;
            try
            {
                smtp.Send(msg);
                result = true;
            }
            catch(Exception ex)
            {

                result = false;
            }
            return result;
        }
    }
}