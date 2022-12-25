
using Messenger.AppService.DTO.DataTypeObject;

namespace Messenger.AppService.Services.Interface
{
    public partial interface IPanelService
    {
        mesPanelDTO GetById(object id);
        bool SendSMS(int panelId, string body, string[] recipientNumber);
    }
}