using System;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Messenger.DAL;
using Messenger.Repository.Services.Interface;

namespace Messenger.Repository.Services.Imp
{
    public partial class UserRepository : GenericRepository<mesUser>, IUserRepository
    {
        #region ~( Methods )~
       
        public bool CheckOnline(int userId)
        {
            try
            {
                var db = (MessengerContext)DbContext;
                var fkfUserParameter = new ObjectParameter("FkfUser", userId);

              
                var isOnline = new ObjectParameter("@IsOnline", typeof(bool));
                isOnline.Value = false;
             
                ((IObjectContextAdapter)db).ObjectContext.ExecuteFunction("mesCheckOnline", fkfUserParameter, isOnline);

                return (bool)isOnline.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

    }
}
