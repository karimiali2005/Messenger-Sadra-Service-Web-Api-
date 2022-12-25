using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Messenger.AppService.Classes;
using Messenger.AppService.Services.Interface;
using Messenger.AppService.ViewModel;
using Messenger.WebApi.Classes;
using Messenger.WebApi.Classes.CutomFilter;
using Microsoft.Web.Http;

namespace Messenger.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api{version:apiVersion}")]
    public class RegisterController : ApiController
    {
        #region ~( Fields )~
        private readonly IUserService _userService;
        private readonly IPanelService _panelService;
   

        #endregion

        #region ~( Constructors )~
        public RegisterController(IUserService userService, IPanelService panelService)
        {
            _userService = userService;
            _panelService = panelService;
        }
        #endregion ~( Constructors )~


        #region Method

        [Route("Register")]
        public HttpResponseMessage Put(string username, int type = 0, string ip4 = "0.0.0.0", int appVersion = 0)
        {
            try
            {
                if (username.StartsWith("0"))
                {
                    username = username.Remove(0, 1);
                }

                var newUser = 0;
                var publicKey = "";
                var result = _userService.Add(username, type, ip4, appVersion, ref newUser, ref publicKey);

                var isSend = _panelService.SendSMS(1, $"به پیام رسان خوش آمدید، کد تایید شما {result.ActiveCode} است.", new[] { result.number });
               

                if (isSend)
                {
                    var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(result.pkfUser.ToString() + ":::" + newUser + ":::" + publicKey) };
                    return response;

                }
                else
                {
                    var response = new HttpResponseMessage { StatusCode = HttpStatusCode.Conflict };
                    return response;
                }




            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway };
                return response;
            }
        }

        [Route("ValidVerificationCode")]
        public HttpResponseMessage Put(int userId, int verificationCode, string publicKey,string tokenFireBase)
        {
            try
            {
                var privateKey = "";
                var privateKeyRefresh = "";
                var privateKeyExpire = "";
                var publicKeyValid = 0;
                var result = _userService.ValidVerificationCode(userId, verificationCode, publicKey, tokenFireBase, ref publicKeyValid, ref privateKey, ref privateKeyRefresh, ref privateKeyExpire);
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(result.ToString() + ":::" + publicKeyValid + ":::" + privateKey + ":::" + privateKeyRefresh + ":::" + privateKeyExpire) };
                return response;

            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway };
                return response;
            }
        }
        [Route("ChangeTokenFireBase")]
        public HttpResponseMessage Put(string userIdString, string tokenFireBase)
        {
            try
            {
                var userId=Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(userIdString));
                var result = _userService.ChangeTokenFireBase(userId, tokenFireBase);
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(result.ToString()) };
                return response;

            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway };
                return response;
            }
        }
        [Route("GetCheckOnline")]
        [HttpRequestMessage]
        public bool GetCheckOnline(string userIdString)
        {
            try
            {
                var userId = Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(userIdString));
                return _userService.CheckOnline(userId);
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }

            return false;

        }

        [Route("RegisterUserInfo")]
        [HttpRequestMessage]
        public HttpResponseMessage Put(UserViewModel user)
        {
            try
            {

                _userService.RegisterUserInfo(user);
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("True") };
                return response;

            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway };
                return response;
            }
        }

        [Route("GetUserInfo")]
        [HttpRequestMessage]
        public UserViewModel GetUserInfo(int userId)
        {
            try
            {
                return _userService.GetUserInfo(userId);
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }

            return null;

        }

        [Route("GetLoadFirstAppInfo")]
        [HttpRequestMessage]
        public LoginLimitViewModel GetLoadFirstAppInfo(int userId, bool isReminder, string ip4 = "0.0.0.0", int appVersion = 0)
        {
            try
            {
                return _userService.GetLoadFirstAppInfo(userId, isReminder, ip4, appVersion);
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }

            return null;

        }

        [Route("upload")]

        public async Task<ServerResponseUpload> Post()
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                //Save To this server location
                var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

                var streamProvider2 = new MyStreamProvider(uploadPath);


                await Request.Content.ReadAsMultipartAsync(streamProvider2);


                var str = "";
                foreach (var file in streamProvider2.FileData)
                {
                    var info = new FileInfo(file.LocalFileName);
                    var userId = info.Name.Split('_')[0];
                    // info.MoveTo("ProfilePic"+userId);
                    _userService.UpdateImage(int.Parse(userId), File.ReadAllBytes(info.FullName));
                    File.Delete(info.FullName);
                    // str = "File uploaded as " + fi.FullName + " (" + fi.Length / 1024 + " M)";
                    str = "دخیره عکس با موفقیت انجام شد";
                }

                return new ServerResponseUpload()
                {
                    success = true,
                    message = str
                };


            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                return new ServerResponseUpload()
                {
                    success = true,
                    message = "ذخیره عکس با مشکل روبرو شد"
                };
            }





        }
        [Route("GetUserPic")]
        //[HttpRequestMessage]
        public HttpResponseMessage GetUserPic(int userId)
        {
            try
            {
                var user = _userService.GetById2(userId);
                byte[] imgData = user.pic;
                MemoryStream ms = new MemoryStream(imgData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                return response;
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                return null;
            }

        }

        [Route("GetUserPicName")]
      //  [HttpRequestMessage]
        public UserPicViewModel GetUserPicName(int userId)
        {
            try
            {
                var user = _userService.GetById2(userId);

                return new UserPicViewModel()
                {
                    UserID = user.pkfUser,
                    UserPicName = user.picName
                };
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                return null;
            }

        }


        #endregion
    }
}
