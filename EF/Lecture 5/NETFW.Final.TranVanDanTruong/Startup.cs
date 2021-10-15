using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NETFW.Final.TranVanDanTruong.Startup))]
namespace NETFW.Final.TranVanDanTruong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
