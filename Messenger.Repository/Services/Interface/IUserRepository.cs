
using Messenger.DAL;

namespace Messenger.Repository.Services.Interface
{
    public partial interface IUserRepository : IGenericRepository<mesUser>
    {
        bool CheckOnline(int userId);
    }
}
