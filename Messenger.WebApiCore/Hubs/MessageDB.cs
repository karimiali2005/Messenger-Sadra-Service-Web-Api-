using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Messenger.WebApiCore.Classes;
using Messenger.WebApiCore.Services.Imp;
using Messenger.WebApiCore.Services.Interface;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.EventArgs;

namespace Messenger.WebApiCore.Hubs
{


    public class MessageDB
    {
        #region ~( Fields )~
        private static readonly IUserService _userService = new UserService();
        #endregion

        #region ~( Methods )~
        public static void ProgramDepency()
        {
            try
            {
                var _con = Startup._connection;
                var mapper = new ModelToTableMapper<mesMessage>();
                mapper.AddMapping(c => c.pkfMessage, "pkfMessage");
                mapper.AddMapping(c => c.FkfUser, "FkfUser");
                mapper.AddMapping(c => c.message, "message");
               // mapper.AddMapping(c => c.FkfStatusMessage, "FkfStatusMessage");
                mapper.AddMapping(c => c.FkfTypeMessage, "FkfTypeMessage");
                mapper.AddMapping(c => c.FkfSource, "FkfSource");
                mapper.AddMapping(c => c.FkfCompanyId, "FkfCompanyId");
                mapper.AddMapping(c => c.isDelete, "isDelete");
                mapper.AddMapping(c => c.FkfDocument, "FkfDocument");

                var dep = new SqlTableDependency<mesMessage>(_con, "mesMessage", mapper: mapper);
                dep.OnChanged += HandleOnChanged;
                dep.Start();

                //using (var dep = new SqlTableDependency<message>(_con, "mesMessage", mapper: mapper))
                //{

                //    dep.OnChanged += Changed;
                //    dep.Start();

                //    //   Console.WriteLine("Press a key to exit");
                //    //  Console.ReadKey();

                //    //   dep.Stop();
                //}
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }
        }

        private static void HandleOnChanged(object sender, RecordChangedEventArgs<mesMessage> e)
        {
            try
            {


                //if (e.ChangeType == TableDependency.SqlClient.Base.Enums.ChangeType.Insert)
                //{
                //   var str=(e.Entity);
                //}
                var changedEntity = e.Entity;
                if (_userService.CheckOnline((int)changedEntity.FkfUser))
                {

                    SendNotificationSignalR("User" + changedEntity.FkfUser, e.ChangeType.ToString());
                }
                else
                {
                    int idcompany = (int)e.Entity.FkfCompanyId;
                    SendNotificationFireBase(e.Entity.pkfMessage,_userService.GetTokenFireBase((int)changedEntity.FkfUser),
                        e.Entity.message.Length <= 5 ? e.Entity.message : e.Entity.message.Substring(0, 5), idcompany);
                }
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }
        }


        private static void SendNotificationSignalR(string reciever, string message)
        {
            try
            {


                //string messageList = GetAllMessagesLog();
                Task.Run(async () =>
                {
                    await Startup._context.Clients.All.SendAsync(reciever, "DB", message);
                    //await Clients.Others.SendAsync(usersend, name, message);
                });
                //IHubContext context = GlobalHost.ConnectionManager.GetHubContext<goodsHub>();
                //context.Clients.All.broadcastMessage(messageList);//Will update all the clients with message log.
                //context.Clients.All.reload();
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }
        }

        private static void SendNotificationFireBase(int pkfMessage, string reciever, string message, int idcompaney)
        {
            try
            {


                var pn = new PushNotification();
                Task.Run(async () => { await pn.SendNotificationAsync(reciever, "DB", message, idcompaney); });

                _userService.UpdateIsFireBase(pkfMessage);
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
            }




        }
        #endregion
    }
}
