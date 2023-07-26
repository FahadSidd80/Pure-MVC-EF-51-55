using System.Web;
using System.Web.Mvc;

namespace WebApp_MVC_L54_JOIN_EF_28523
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
