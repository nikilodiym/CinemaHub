namespace Core.Contracts;

public interface INotificationService
{
    void SendNotification(string recipient, string message);
    void SendEmail(string email, string subject, string body);
    void SendSms(string phoneNumber, string message);
}