using System.Data.Entity;

namespace Messenger.DAL
{
    public partial class MessengerContext : DbContext
    {
        public MessengerContext(string connection) :
            base(connection)
        {

        }
    }
}
