using System;
using System.Collections.Generic;
using Messenger.DAL;

namespace Messenger.Repository.Services.Interface
{
    public interface ICompanyRepository: IGenericRepository<mesCompany>
    {
        //List<mesCompanyShow_Result> CompanyShow(int userId, string number);
        List<mesCompanyChange_Result> CompanyChange(int userId, string number, DateTime changeDate);
        List<mesMessageChange_Result> MessageChange(int userId, DateTime changeDate);
        List<mesStatusMessageChange_Result> StatusMessageChange(DateTime changeDate);
        List<mesTypeMessageChange_Result> TypeMessageChange(DateTime changeDate);
        List<mesMessageShow_Result> MessageShow(int companyId,int userId, DateTime changeDate);
    }
}
