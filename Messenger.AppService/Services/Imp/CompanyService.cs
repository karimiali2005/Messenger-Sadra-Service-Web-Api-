using System;
using System.Collections.Generic;
using Messenger.AppService.DTO.DataTypeObject;
using Messenger.AppService.Services.Interface;
using Messenger.DAL;
using Messenger.Repository.Services.Interface;

namespace Messenger.AppService.Services.Imp
{
    public class CompanyService:ICompanyService
    {
        #region ~( Fields )~

        private readonly ICompanyRepository _companyRepository;

        #endregion

        #region ~( Constructors )~
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        #endregion

        #region ~( Methods )~
        public mesCompanyDTO GetById(object id)
        {
            try
            {
                var company = _companyRepository.GetByKey(id);
                var companyDTO = new mesCompanyDTO();
                AutoMapper.Mapper.Map(company, companyDTO);
                return companyDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<mesCompanyShow_ResultDTO> CompanyShow(int userId, string number)
        //{
        //    try
        //    {
        //        var company = _companyRepository.CompanyShow(userId, number);
        //        var companyDTO = new List<mesCompanyShow_ResultDTO>();
        //        AutoMapper.Mapper.Map(company, companyDTO);
        //        return companyDTO;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public List<mesCompanyChange_ResultDTO> CompanyChange(int userId, string number, DateTime changeDate)
        {
            try
            {
                var company = _companyRepository.CompanyChange(userId, number,changeDate);
                var companyDTO = new List<mesCompanyChange_ResultDTO>();
                AutoMapper.Mapper.Map(company, companyDTO);
                return companyDTO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<mesMessageChange_ResultDTO> MessageChange(int userId, DateTime changeDate)
        {
            try
            {
                var message = _companyRepository.MessageChange(userId, changeDate);
                var messageDTO = new List<mesMessageChange_ResultDTO>();
                AutoMapper.Mapper.Map(message, messageDTO);
                return messageDTO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<mesStatusMessageChange_ResultDTO> StatusMessageChange(DateTime changeDate)
        {
            try
            {
                var statusMessage = _companyRepository.StatusMessageChange(changeDate);
                var statusMessageDTO = new List<mesStatusMessageChange_ResultDTO>();
                AutoMapper.Mapper.Map(statusMessage, statusMessageDTO);
                return statusMessageDTO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<mesTypeMessageChange_ResultDTO> TypeMessageChange(DateTime changeDate)
        {
            try
            {
                var typeMessage = _companyRepository.TypeMessageChange(changeDate);
                var typeMessageDTO = new List<mesTypeMessageChange_ResultDTO>();
                AutoMapper.Mapper.Map(typeMessage, typeMessageDTO);
                return typeMessageDTO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<mesMessageShow_ResultDTO> MessageShow(int companyId,int userId, DateTime changeDate)
        {
            try
            {
                var message = _companyRepository.MessageShow(companyId,userId, changeDate);
                var messageDTO = new List<mesMessageShow_ResultDTO>();
                AutoMapper.Mapper.Map(message, messageDTO);
                return messageDTO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
