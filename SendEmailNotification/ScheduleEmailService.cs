using SendEmailNotification.Interface;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SendEmailNotification
{
    public class ScheduleEmailService : BackgroundService
    {
        private readonly IemailService _emailService;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1); // Trigger email every 10 minutes

        public ScheduleEmailService(IemailService emailService)
        {
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _emailService.SendEmailAsync("jugalkishorupadhyay99@gmail.com", "Scheduled Email", "This is your scheduled email sent every 10 minutes.");


                // Wait for the next 10-minute interval
                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
