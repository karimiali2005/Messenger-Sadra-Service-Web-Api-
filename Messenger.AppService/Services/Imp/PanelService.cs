using System;
using Messenger.AppService.DTO.DataTypeObject;
using Messenger.AppService.Services.Interface;
using Messenger.Repository.Services.Interface;
using Messenger.SMSPanel;

namespace Messenger.AppService.Services.Imp
{
    public partial class PanelService: IPanelService
    {
        #region ~( Fields )~

        private readonly IPanelRepository _panelRepository;
        private readonly ISettingRepository _settingRepository;

        #endregion

        #region ~( Constructors )~
        public PanelService(IPanelRepository panelRepository,ISettingRepository settingRepository)
        {
            _panelRepository = panelRepository;
            _settingRepository = settingRepository;
        }

        #endregion

        #region ~( Methods )~
        public mesPanelDTO GetById(object id)
        {
            try
            {
                var panel = _panelRepository.GetByKey(id);

                var panelDTO = new mesPanelDTO();
                AutoMapper.Mapper.Map(panel, panelDTO);

                return panelDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SendSMS(int panelId, string body, string[] recipientNumber)
        {
            try
            {
                var panel = GetById(panelId);
                if (panel != null)
                {
                    //var service=new KashanSMS();
                    var service=new KashanSMS();
                    return service.Send(panel.UserName, panel.UserPass, body, panel.Sender, recipientNumber);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return false;
        }

       

        #endregion
    }
}
