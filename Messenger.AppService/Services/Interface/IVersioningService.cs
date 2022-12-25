using Messenger.AppService.ViewModel;

namespace Messenger.AppService.Services.Interface
{
    public interface IVersioningService
    {
        LoginLimitViewModel GetLoadVersion();
    }
}
