using System;
using System.Collections.Generic;
using System.Linq;
using Messenger.DAL;
using Messenger.Repository.Services.Interface;

namespace Messenger.Repository.Services.Imp
{
    public partial class CompanyRepository : GenericRepository<mesCompany>, ICompanyRepository
    {
        //public List<mesCompanyShow_Result> CompanyShow(int userId,string number)
        //{
        //    try
        //    {
        //        var db = (MessengerContext)DbContext;
        //        var result = db.mesCompanyShow(userId,number).ToList();
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public List<mesCompanyChange_Result> CompanyChange(int userId,string number, DateTime changeDate)
        {
            try
            {
                var db = (MessengerContext)DbContext;
                var result = db.mesCompanyChange( userId,number, changeDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<mesMessageChange_Result> MessageChange(int userId, DateTime changeDate)
        {
            try
            {
                var db = (MessengerContext)DbContext;
                var result = db.mesMessageChange(userId, changeDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<mesStatusMessageChange_Result> StatusMessageChange(DateTime changeDate)
        {
            try
            {
                var db = (MessengerContext)DbContext;
                var result = db.mesStatusMessageChange(changeDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<mesTypeMessageChange_Result> TypeMessageChange(DateTime changeDate)
        {
            try
            {
                var db = (MessengerContext)DbContext;
                var result = db.mesTypeMessageChange(changeDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        

        public List<mesMessageShow_Result> MessageShow(int companyId,int userId, DateTime changeDate)
        {
            try
            {
                var db = (MessengerContext)DbContext;
                var result = db.mesMessageShow(companyId,userId, changeDate).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
