using System.Web;
using System.Web.Mvc;

namespace database_first_aspnet_app_mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
