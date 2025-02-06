using NETCore.MailKit.Core;
using Quartz;

namespace SendEmailNotification
{
    public class EmailJob : IJob
    {
        private readonly EmailService _emailService;

        public EmailJob(EmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            // Trigger the email sending logic
            await _emailService.SendEmailAsync("jugalkishorupadhyay99@gmail.com", "Scheduled Email", "This email is sent every 10 minutes.");
        }
    }
}
