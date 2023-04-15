using System.Web;
using System.Web.Mvc;

namespace database_first_mvc_aspnet_app
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
