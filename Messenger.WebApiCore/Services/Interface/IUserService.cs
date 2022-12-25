using Messenger.WebApiCore.Classes;

namespace Messenger.WebApiCore.Services.Interface
{
    public interface IUserService
    {
        void OnConnectApp(int userId, string idConnectionSignalR, int loginTypee, string ip, int appVersion,string androidVersion,string mobileName);
        void OnDisConnectApp(string idConnectionSignalR);
        bool CheckOnline(int userId);
        string GetTokenFireBase(int userId);
        mesSetting GetSettingFireBase();
        void UpdateIsFireBase(int pkfMessage);
    }
}