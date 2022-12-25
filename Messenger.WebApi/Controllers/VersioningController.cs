using System;
using System.Web.Http;
using Messenger.AppService.Services.Interface;
using Messenger.AppService.ViewModel;
using Messenger.WebApi.Classes;
using Microsoft.Web.Http;

namespace Messenger.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api{version:apiVersion}")]
    public class VersioningController : ApiController
    {
        #region ~( Fields )~

        private readonly IVersioningService _versioningService;

        #endregion

        #region ~( Constructors )~
        public VersioningController(IVersioningService versioningService)
        {

            _versioningService = versioningService;
        }
        #endregion

        #region ~( Methods )~
        [Route("GetLoadVersion")]
        public LoginLimitViewModel GetLoadVersion()
        {
            try
            {
                return _versioningService.GetLoadVersion();
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }
            return null;

        }
        #endregion
    }
}
