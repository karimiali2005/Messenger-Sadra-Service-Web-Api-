using System;
using System.Linq;
using Messenger.AppService.Services.Interface;
using Messenger.AppService.ViewModel;
using Messenger.Repository.Services.Interface;

namespace Messenger.AppService.Services.Imp
{
    public class VersioningService:IVersioningService
    {
        #region ~( Fields )~

        private readonly IVersioningRepository _versioningRepository;
       
        #endregion

        #region ~( Constructors )~
        public VersioningService(IVersioningRepository versioningRepository)
        {
            _versioningRepository = versioningRepository;
        }

        #endregion

        #region ~( Methods )~
        public LoginLimitViewModel GetLoadVersion()
        {
            try
            {
                var lastForce = _versioningRepository.Get(v => v.ForceInstalling).LastOrDefault();
                var lastNoForce = _versioningRepository.GetAll().LastOrDefault();
                var loginLimit = new LoginLimitViewModel()
                {
                    DeactiveAdministrator = false,
                    VersionCodeForceInstalling = lastForce.VersionCode,
                    VersionNameForceInstalling = lastForce.VersionName,
                    VersionCodeNoForceInstalling = lastNoForce.VersionCode,
                    VersionNameNoForceInstalling = lastNoForce.VersionName,
                };
                return loginLimit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
