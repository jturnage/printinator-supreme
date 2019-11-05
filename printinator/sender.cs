using System;
using System.Linq;
using System.Net.Mail;

namespace printinator
{

    public class Address
    {
        public string Display { get; set; }
        public string Email { get; set; }
    }

    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Server
    {
        public string Host { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public Credentials Credentials { get; set; }
        public bool EnableSsl { get; set; }
    }

    public class EmailMessage
    {
        public string Subject { get; set; }
        public Address[] To { get; set; }
        public Address[] CC { get; set; }
        public Address From { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Sender
    {
        public static Response SendMail(Server server, EmailMessage email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email.From.Email, email.From.Display);
                mail.Subject = email.Subject;
                mail.Body = email.Body;
                mail.IsBodyHtml = email.IsBodyHtml;

                if (email.CC != null)
                {
                    email.CC.Select(_ => new MailAddress(_.Email, _.Display))
                            .ToList()
                            .ForEach(_ => { mail.CC.Add(_); });
                }

                if (email.To != null)
                {
                    email.To.Select(_ => new MailAddress(_.Email, _.Display))
                            .ToList()
                            .ForEach(_ => { mail.To.Add(_); });
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = server.Host;
                smtp.EnableSsl = server.EnableSsl;
                smtp.UseDefaultCredentials = server.UseDefaultCredentials;
                if (server.Credentials != null)
                {
                    smtp.Credentials = new System.Net.NetworkCredential(server.Credentials.Username, server.Credentials.Password);
                }
                smtp.Send(mail);

                return new Response { Success = true };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, ErrorMessage = ex.Message};
            }
        }
    }
}
