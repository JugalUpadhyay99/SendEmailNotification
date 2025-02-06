using SendEmailNotification.Interface;
using SendEmailNotification;
using Hangfire;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IemailService, EmailService>();  // Register EmailService
builder.Services.AddHostedService<ScheduleEmailService>();



builder.Services.AddQuartz(q => q.UseMicrosoftDependencyInjectionJobFactory());
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);



void Configure(IApplicationBuilder app, IBackgroundJobClient backgroundJobs)
{
    // Start Hangfire dashboard (optional for monitoring jobs)
    app.UseHangfireDashboard();

    // Schedule the email job to run every 10 minutes
    var emailJobScheduler = app.ApplicationServices.GetRequiredService<EmailJobScheduler>();
    emailJobScheduler.Scheduleemails();
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();


