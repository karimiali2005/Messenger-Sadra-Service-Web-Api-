using System;
using System.Threading.Tasks;
using Messenger.AppService.Classes;
using Messenger.WebApiCore.Classes;
using Messenger.WebApiCore.Services.Imp;
using Messenger.WebApiCore.Services.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Messenger.WebApiCore.Hubs
{
    public class Message : Hub
    {
        #region ~( Fields )~
        private IUserService _userService;
        #endregion

        #region ~( Constructors )~
        public Message()
        {
            _userService = new UserService();
        }
        #endregion

        #region ~( Methods )~
        public async Task SendMessage(string reciever, string sender, string message)
        {
            try
            {
                await Clients.Others.SendAsync(reciever, sender, message);

                // await Clients.User(usersend).SendAsync("asde", name, message);
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }

        }
        public override async Task OnConnectedAsync()
        {
            try
            {


                var httpCtx = Context.GetHttpContext();
                //var someHeaderValue = httpCtx.Request.Headers["UserName"].ToString();
                //var userName = AesEncryptionAlgorithm.DecryptServiceUserReceive(someHeaderValue);

                //var userId = userName.Substring(4, userName.Length - 1).Split(":::")[0];
                //var loginType = userName.Substring(4, userName.Length - 1).Split(":::")[1];
                //var appVersion = userName.Substring(4, userName.Length - 1).Split(":::")[2];

                var someHeaderValue = httpCtx.Request.Headers["userId"].ToString();

                var userId = someHeaderValue.Remove(0, 4);
                var loginType = httpCtx.Request.Headers["loginType"].ToString();
                var appVersion = httpCtx.Request.Headers["appVersion"].ToString();
                var ip = httpCtx.Request.Headers["ip"].ToString();
                var mobileName = httpCtx.Request.Headers["modelmobile"].ToString();
                var androidVertion = httpCtx.Request.Headers["skdmobile"].ToString();
                _userService.OnConnectApp(Convert.ToInt32(userId), Context.ConnectionId, Convert.ToInt32(loginType), ip,
                    Convert.ToInt32(appVersion), androidVertion, mobileName);

                await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");

                await base.OnConnectedAsync();
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            try
            {
                _userService.OnDisConnectApp(Context.ConnectionId);

                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
                await base.OnDisconnectedAsync(exception);
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }

        }
        #endregion

    }
}
