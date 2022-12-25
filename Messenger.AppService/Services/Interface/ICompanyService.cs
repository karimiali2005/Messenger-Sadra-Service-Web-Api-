using System;
using System.Collections.Generic;
using Messenger.AppService.DTO.DataTypeObject;
using Messenger.DAL;

namespace Messenger.AppService.Services.Interface
{
    public interface ICompanyService
    {
        //List<mesCompanyShow_ResultDTO> CompanyShow(int userId, string number);
        mesCompanyDTO GetById(object id);
        List<mesCompanyChange_ResultDTO> CompanyChange(int userId, string number, DateTime changeDate);
        List<mesMessageChange_ResultDTO> MessageChange(int userId, DateTime changeDate);
        List<mesStatusMessageChange_ResultDTO> StatusMessageChange(DateTime changeDate);
        List<mesTypeMessageChange_ResultDTO> TypeMessageChange(DateTime changeDate);
        List<mesMessageShow_ResultDTO> MessageShow(int companyId,int userId, DateTime changeDate);
    }
}
