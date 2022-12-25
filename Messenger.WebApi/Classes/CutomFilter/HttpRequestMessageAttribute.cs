using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Messenger.AppService.Classes;
using Messenger.AppService.Services.Interface;
using Messenger.WebApi.App_Start;

namespace Messenger.WebApi.Classes.CutomFilter
{

    public class HttpRequestMessageAttribute : System.Web.Http.Filters.ActionFilterAttribute

    {

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)

        {
            var request = actionContext.Request;
            try
            {


                


                var headerValues = request.Headers.GetValues("Authorize");
                var keyPrivate = headerValues.FirstOrDefault();

                keyPrivate = AesEncryptionAlgorithm.DecryptServicePrivateKeySend(keyPrivate);

                var headerValuesUser = request.Headers.GetValues("User");
                var userId = headerValuesUser.FirstOrDefault();

                var _userService = StructuremapMvc.StructureMapDependencyScope.Container.GetInstance<IUserService>();
                if(!_userService.Authorize(int.Parse(userId),keyPrivate))
                    actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            catch(Exception ex)
            {
                /*if (!(request.RequestUri!=null && request.RequestUri.AbsoluteUri!=App.Communication.ApiRegister && request.RequestUri.AbsoluteUri != App.Communication.ApiRegister))
                {*/
                    actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized);
               /* }*/
               
            }
            /*var headers = request.Headers;
              

            if (!headers.Contains("X-Requested-With") || headers.GetValues("X-Requested-With").FirstOrDefault() !=
                "XMLHttpRequest")

                actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized);*/

        }

    }

}