using Messenger.DAL;

namespace Messenger.AppService.Services.Interface
{
    public interface IMessageService
    {
        mesMessage GetById(object id);
        void UpdateReciveDate(int pkfMessage);
        void UpdateShowDate(int pkfMessage);
        void UpdateAnswerDate(int pkfMessage, int replay, string comment);
    }
}
