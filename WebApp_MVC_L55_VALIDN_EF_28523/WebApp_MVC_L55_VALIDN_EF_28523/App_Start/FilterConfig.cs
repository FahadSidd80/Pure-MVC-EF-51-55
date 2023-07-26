using System.Web;
using System.Web.Mvc;

namespace WebApp_MVC_L55_VALIDN_EF_28523
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
