using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Messenger.WebApiCore.Services.Imp;
using Messenger.WebApiCore.Services.Interface;

namespace Messenger.WebApiCore.Hubs
{
    //Install-Package Newtonsoft.Json -Version 12.0.3
    public class PushNotification
    {
        #region ~( Fields )~
        private IUserService _userService;
        #endregion

        #region ~( Constructors )~
        public PushNotification()
        {
            _userService = new UserService();
        }
        #endregion

        #region ~( Methods )~
        public async Task<bool> SendNotificationAsync(string token, string title, string body, int idcompaney)
        {
            try
            {
                title = "پیغام جدید";
                //  body = "شما یک پیغام جدید دارید ";


                using (var client = new HttpClient())
                {


                    var setting = _userService.GetSettingFireBase();

                    client.BaseAddress = new Uri(setting.webAddr);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization",
                        $"key={setting.serverKeyFireBase}");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", $"id={setting.senderIdFireBase}");


                    var datamesg = new
                    {
                        to = token,
                        notification = new
                        {
                            body = body,
                            title = title,
                            idc = idcompaney,
                            // click_action = ".subMesssage",
                        },
                        data = new
                        {
                            idc = idcompaney,

                        },

                        priority = "high"
                    };

                    var json = JsonConvert.SerializeObject(datamesg);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync("/fcm/send", httpContent);
                    return result.StatusCode.Equals(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
