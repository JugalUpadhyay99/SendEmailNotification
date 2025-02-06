namespace SendEmailNotification.Interface
{
    public interface IemailService
    {
            Task SendEmailAsync(string to, string subject, string body);
    }
}
