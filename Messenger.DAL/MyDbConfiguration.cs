using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace Messenger.DAL
{
    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration() : base()
        {
            SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
            SetProviderServices("System.Data.SqlClient",
                System.Data.Entity.SqlServer.SqlProviderServices.Instance);

            // var appDataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data");
            var appDataDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location); ;
            SetModelStore(new DefaultDbModelStore(appDataDirectory));

        }
    }
}
