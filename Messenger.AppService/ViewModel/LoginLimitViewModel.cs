namespace Messenger.AppService.ViewModel
{
    public class LoginLimitViewModel
    {
        public bool DeactiveAdministrator { get; set; }
        public int VersionCodeForceInstalling { get; set; }
        public string VersionNameForceInstalling { get; set; }
        public int VersionCodeNoForceInstalling { get; set; }
        public string VersionNameNoForceInstalling { get; set; }

    }
}
