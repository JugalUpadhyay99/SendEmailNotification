using Hangfire;
using NETCore.MailKit.Core;
using Quartz;
using SendEmailNotification.Interface;

namespace SendEmailNotification
{
    public class EmailJobScheduler
    {
        
            private readonly IemailService _emailService;

            public EmailJobScheduler(IemailService emailService)
            {
                _emailService = emailService;
            }

        public void Scheduleemails()
        {
            // hangfire job that will run every 10 minutes
            RecurringJob.AddOrUpdate(
            () => _emailService.SendEmailAsync("recipient@example.com", "Scheduled Email", "This email is sent every 10 minutes."),
            "*/10 * * * *");
        }

    }
    
}
