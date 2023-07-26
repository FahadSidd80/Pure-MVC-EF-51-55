using System.Web;
using System.Web.Mvc;

namespace WebApp_MVC_L51_Razor_EF_27523
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
