using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace ASP_Core_hw_EmailClient_RazorPages.Pages
{
    public class SendModel : PageModel
    {
        private readonly Context _db;

        public SendModel(Context context)
        {
            _db = context;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(Message message)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            string mailFrom = message.From;
            MailAddress _from = new MailAddress(mailFrom, "Abai");
            // кому отправляем
            MailAddress _to = new MailAddress(message.To);
            // создаем объект сообщения
            MailMessage m = new MailMessage(_from, _to);
            // тема письма
            m.Subject = message.Title;
            // текст письма
            m.Body = message.Text;
            // письмо представляет код html
            m.IsBodyHtml = false;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            // логин и пароль
            string password = "pswrd";
            smtp.Credentials = new NetworkCredential(mailFrom, password);
            smtp.EnableSsl = true;
            smtp.Send(m);

            _db.Messages.Add(message);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");

            
        }

        
    }
}
