using Messenger.DAL;
using Messenger.Repository.Services.Interface;

namespace Messenger.Repository.Services.Imp
{
    public partial class MessageRepository :GenericRepository<mesMessage>, IMessageRepository
    {
    }
}
