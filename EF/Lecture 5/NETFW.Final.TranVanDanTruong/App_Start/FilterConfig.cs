using System.Web;
using System.Web.Mvc;

namespace NETFW.Final.TranVanDanTruong
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
