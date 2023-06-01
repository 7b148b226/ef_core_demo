using System;
using System.Web;
using System.Web.Http;

namespace ef_6_with_.net_4
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
