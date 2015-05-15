using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CardSite1.Infrastructure;
using System.Globalization;
using System.Threading;

namespace CardSite1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            string cultureName = null;
            HttpCookie cultureCookie = context.Request.Cookies["lang"];
            String defaultLang = "ru";
            cultureName = getCultureName(cultureCookie, defaultLang);
            List<string> cultures = new List<string>() { defaultLang, "en", "de" };
            if (!cultures.Contains(cultureName))
            {
                cultureName = defaultLang;
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(cultureName);
        }

        private String getCultureName(HttpCookie cultureCookie, String defaultLang)
        {
            return cultureCookie != null ? cultureCookie.Value : defaultLang;
        }
    }
}
