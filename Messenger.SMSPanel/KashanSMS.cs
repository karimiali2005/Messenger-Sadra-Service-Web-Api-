using System;
using Messenger.SMSPanel.KashanSMSReference;


namespace Messenger.SMSPanel
{
    public class KashanSMS:IKashanSMS
    {
        public bool Send(string userName, string password, string body, string senderNumber, string[] recipientNumber)
        {
            try
            {
                var serviceSms = new SendSoapClient();
                var arrayNumber = new ArrayOfString();
                foreach (var str in recipientNumber)
                {
                    arrayNumber.Add(str);
                }
                serviceSms.SendSmsAsync(userName, password, arrayNumber, senderNumber, body, false, "", null, null);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
