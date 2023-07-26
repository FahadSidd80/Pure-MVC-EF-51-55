using System.Web;
using System.Web.Mvc;

namespace WebAp_MVC_L52_EF_Razor_CRUD_28523
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
