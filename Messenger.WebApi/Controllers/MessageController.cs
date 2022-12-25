using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Messenger.AppService.DTO.DataTypeObject;
using Messenger.AppService.Services.Interface;
using Messenger.AppService.ViewModel;
using Messenger.WebApi.Classes;
using Messenger.WebApi.Classes.CutomFilter;
using Messenger.AppService.Classes;

namespace Messenger.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [RoutePrefix("api{version:apiVersion}")]
    public class MessageController : ApiController
    {
        #region ~( Fields )~
        private readonly ICompanyService _companyService;
        private readonly IMessageService _messageService;


        #endregion
        #region ~( Constructors )~
        public MessageController(ICompanyService companyService,IMessageService messageService)
        {
            _companyService = companyService;
            _messageService = messageService;
        }
        #endregion ~( Constructors )~


        #region Method

        [Route("GetReceiveAll")]
        [HttpRequestMessage]
        public ReceiveAllViewModel GetReceiveAll(string userIdString, string number,string changeDate)
        {
            try
            {
                var userId=Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(userIdString));
                number = AesEncryptionAlgorithm.DecryptServiceUserReceive(number);
                var date = Convert.ToDateTime(changeDate).AddSeconds(-5);
                var receive = new ReceiveAllViewModel()
                {
                    ListCompany = _companyService.CompanyChange(userId, number, date),
                    ListMessage = _companyService.MessageChange(userId, date),
                    ListStatusMessage = _companyService.StatusMessageChange(date),
                    ListTypeMessage = _companyService.TypeMessageChange(date),
                    ChangeDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                };
                

                return receive;
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                return null;
            }

        }
        [Route("UpdateDateTime")]
        [HttpRequestMessage]
        public HttpResponseMessage Put(string pkfMessageString,int type=1)
        {
            try
            {
                if (type==1)
                {
                    var pkfMessage = Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(pkfMessageString));
                    _messageService.UpdateReciveDate(pkfMessage);
                }
                else
                {
                    var pkfMessage = Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(pkfMessageString));
                    _messageService.UpdateShowDate(pkfMessage);

                }

                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("True") };
                return response;

            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway };
                return response;
            }
        }
        [Route("UpdateAnswerTime")]
        [HttpRequestMessage]
        public HttpResponseMessage Put(string pkfMessageString, int replay, string comment)
        {
            try
            {
                var pkfMessage = Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(pkfMessageString));
                    _messageService.UpdateAnswerDate(pkfMessage,replay,comment);
               
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("True") };
                return response;

            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                var response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway };
                return response;
            }
        }



        //[Route("GetCompanyShow")]
        //[HttpRequestMessage]
        //public List<mesCompanyShow_ResultDTO> GetCompanyShow(int userId,string number)
        //{
        //    try
        //    {
        //        var company = _companyService.CompanyShow(userId,number);

        //        return company;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToSaveElmah();
        //        return null;
        //    }

        //}
        //[Route("GetMessageShow")]
        //[HttpRequestMessage]
        //public List<mesMessageShow_ResultDTO> GetMessageShow(int companyId,int userId, string changeDate)
        //{
        //    try
        //    {
        //        var message = _companyService.MessageShow(companyId, userId, Convert.ToDateTime(changeDate));
        //        return message;
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.ToSaveElmah();
        //        return null;
        //    }

        //}

        [Route("GetCompanyPic")]
        public HttpResponseMessage GetCompanyPic(string companyIdString)
        {
            try
            {
                var companyId = Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(companyIdString));
                var company = _companyService.GetById(companyId);
                byte[] imgData = company.pic;
                MemoryStream ms = new MemoryStream(imgData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                return response;
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                return null;
            }

        }

        [Route("GetCompanyPicName")]
        public CompanyPicViewModel GetCompanyPicName(string companyIdString)
        {
            try
            {
                var companyId = Convert.ToInt32(AesEncryptionAlgorithm.DecryptServiceUserReceive(companyIdString));
                var company = _companyService.GetById(companyId);

                return new CompanyPicViewModel()
                {
                    CompanyID = company.pkfCompany,
                    CompanyPicName = company.picName
                };
            }
            catch (Exception ex)
            {
                ex.ToSaveElmah();
                return null;
            }

        }
        #endregion
    }
}
