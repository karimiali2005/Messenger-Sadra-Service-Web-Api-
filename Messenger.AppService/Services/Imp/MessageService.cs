using Messenger.AppService.Services.Interface;
using Messenger.DAL;
using Messenger.Repository.Services.Interface;
using System;
using System.Globalization;

namespace Messenger.AppService.Services.Imp
{
    public partial class MessageService:IMessageService
    {
        #region ~( Fields )~

        private readonly IMessageRepository _messageRepository;
        


        #endregion

        #region ~( Constructors )~
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        #endregion

        #region ~( Methods )~

        public mesMessage GetById(object id)
        {
            try
            {
                var user = _messageRepository.GetByKey(id);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateReciveDate(int pkfMessage)
        {
            try
            {
                var message = GetById(pkfMessage);
                message.reciveDateEN = DateTime.Now;
                message.reciveTime = DateTime.Now.ToString("HH:mm");
                var persianCalendar = new PersianCalendar();
                message.reciveDate= persianCalendar.GetYear(DateTime.Now).ToString("0000") + "/" +
                                             persianCalendar.GetMonth(DateTime.Now).ToString("00") + "/" +
                                             persianCalendar.GetDayOfMonth(DateTime.Now).ToString("00");
               // message.changeDateEN = DateTime.Now;
                message.FkfStatusMessage = 3;
                _messageRepository.Update(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateShowDate(int pkfMessage)
        {
            try
            {
                var message = GetById(pkfMessage);
                message.showDateEN= DateTime.Now;
                message.showTime = DateTime.Now.ToString("HH:mm");
                var persianCalendar = new PersianCalendar();
                message.showDate = persianCalendar.GetYear(DateTime.Now).ToString("0000") + "/" +
                                             persianCalendar.GetMonth(DateTime.Now).ToString("00") + "/" +
                                             persianCalendar.GetDayOfMonth(DateTime.Now).ToString("00");
               // message.changeDateEN = DateTime.Now;
                message.FkfStatusMessage = 4;
                _messageRepository.Update(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateAnswerDate(int pkfMessage,int replay,string comment)
        {
            try
            {
                var message = GetById(pkfMessage);
                message.ansswerDateEN = DateTime.Now;
                message.ansswerTime = DateTime.Now.ToString("HH:mm");
                var persianCalendar = new PersianCalendar();
                message.ansswerDate = persianCalendar.GetYear(DateTime.Now).ToString("0000") + "/" +
                                   persianCalendar.GetMonth(DateTime.Now).ToString("00") + "/" +
                                   persianCalendar.GetDayOfMonth(DateTime.Now).ToString("00");
                // message.changeDateEN = DateTime.Now;
                message.FkfStatusMessage = 5;
                message.replay = replay;
                message.replayDiscript = comment;
                _messageRepository.Update(message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
