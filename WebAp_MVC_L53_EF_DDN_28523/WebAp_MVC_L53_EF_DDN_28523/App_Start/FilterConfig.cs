using System.Web;
using System.Web.Mvc;

namespace WebAp_MVC_L53_EF_DDN_28523
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
