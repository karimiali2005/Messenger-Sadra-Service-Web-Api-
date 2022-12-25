using Messenger.AppService.DTO.DataTypeObject;
using System.Collections.Generic;

namespace Messenger.AppService.ViewModel
{
    public class ReceiveAllViewModel
    {
        public List<mesCompanyChange_ResultDTO> ListCompany { get; set; }
        public List<mesMessageChange_ResultDTO> ListMessage { get; set; }
        public List<mesStatusMessageChange_ResultDTO> ListStatusMessage { get; set; }
        public List<mesTypeMessageChange_ResultDTO> ListTypeMessage { get; set; }
        public string ChangeDate { get; set; }
    }
}
