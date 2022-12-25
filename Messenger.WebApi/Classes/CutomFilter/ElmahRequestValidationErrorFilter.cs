using System.Web;
using System.Web.Mvc;
using Elmah;

namespace Messenger.WebApi.Classes.CutomFilter
{
    /// <summary>
    /// ثبت استثناهای برنامه توسط elmah
    /// </summary>
    public class ElmahRequestValidationErrorFilter : IExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpRequestValidationException)
                ErrorLog.GetDefault(HttpContext.Current).Log(new Error(context.Exception));
        }
    }
}