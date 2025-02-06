using Hangfire;
using NETCore.MailKit.Core;
using SendEmailNotification.Interface;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SendEmailNotification
{
    public class EmailService : IemailService
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            SmtpClient client = new SmtpClient("smtp.ethereal.email", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("jugalupadhyay1212@gmail.com", "hrokyuymerhzwqbu");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("jugalupadhyay1212@gmail.com");
            mailMessage.To.Add("jugalkishorupadhyay99@gmail.com");
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>Test Email</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Hello World! Test Email</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
           // client.Send(mailMessage);

            await Task.Delay(1);
            Console.WriteLine($"Email sent to {to}: {subject}");

        }
        //public class EmailJobScheduler
        //{
        //    private readonly IemailService _emailService;

        //    public EmailJobScheduler(IemailService emailService)
        //    {
        //        _emailService = emailService;
        //    }

        //    public void Scheduleemails()
        //    {
        //        // Hangfire job that will run every 10 minutes
        //        RecurringJob.AddOrUpdate(() => _emailService.SendEmailAsync("jugalkishorupadhyay99@gmail.com", "Scheduled Email", "This email is sent every 10 minutes."),
        //            "*/1 * * * *");
        //    }
        
    }
}
