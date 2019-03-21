using System.Web;
using System.Web.Mvc;

namespace KFC.Red.DBate.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
