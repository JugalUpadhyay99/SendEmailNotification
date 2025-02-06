using Org.BouncyCastle.Security;
using Quartz;

namespace SendEmailNotification
{
    public class ScheduleJob
    {
        public void Configure(IApplicationBuilder app, IScheduler scheduler)
        {
            var job = JobBuilder.Create<EmailJob>()
                .WithIdentity("ScheduleEmailService")
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity("ScheduleEmailService")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(1)  // Trigger every 10 minutes
                    .RepeatForever())
                .Build();

            // Schedule the job
            scheduler.ScheduleJob(job, trigger);
        }
    }
}

