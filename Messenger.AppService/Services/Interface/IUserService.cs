using Messenger.AppService.DTO.DataTypeObject;
using Messenger.AppService.ViewModel;
using Messenger.DAL;

namespace Messenger.AppService.Services.Interface
{
    public partial interface IUserService
    {
        mesUserDTO Add(string username, int type, string ip4, int appVersion, ref int newUser, ref string publicKey);
        bool ValidVerificationCode(int userId, int verificationCode, string publicKey, string tokenFireBase, ref int publicKeyValid,
            ref string privateKey, ref string privateKeyRefresh, ref string privateKeyExpire);

        bool ChangeTokenFireBase(int userId, string tokenFireBase);
        bool CheckOnline(int userId);
        mesUser GetById(object id);
        mesUserDTO GetById2(object id);
        LoginLimitViewModel GetLoadFirstAppInfo(int userId, bool isReminder, string ip4, int appVersion);
        void RegisterUserInfo(UserViewModel user);
        UserViewModel GetUserInfo(object id);
        void UpdateImage(int userId, byte[] pic);
        bool Authorize(int userId, string publicKey);
    }
}
