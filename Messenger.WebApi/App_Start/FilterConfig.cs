using System.Web.Mvc;
using Messenger.WebApi.Classes.CutomFilter;

namespace Messenger.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahRequestValidationErrorFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
