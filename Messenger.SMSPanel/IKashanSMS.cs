namespace Messenger.SMSPanel
{
    public interface IKashanSMS
    {
        bool Send(string userName, string password, string body, string senderNumber, string[] recipientNumber);
    }
}