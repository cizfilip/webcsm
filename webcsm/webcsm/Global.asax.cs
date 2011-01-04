using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

using System.Security.Principal;
using System.Threading;

namespace webcsm
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        public override void Init()
        {
            this.PostAuthenticateRequest += new EventHandler(Webcsm_PostAuthenticateRequest);
            base.Init();
        }

        void Webcsm_PostAuthenticateRequest(object sender, EventArgs e)
        {
            IPrincipal usr = HttpContext.Current.User;

            // If we are dealing with an authenticated forms authentication request
            if (usr.Identity.IsAuthenticated && usr.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity fIdent = usr.Identity as FormsIdentity;

                // Create a CustomIdentity based on the FormsAuthenticationTicket  
                WebcsmIdentity ci = new WebcsmIdentity(fIdent.Ticket);

                // Create the CustomPrincipal
                WebcsmPrincipal prin = new WebcsmPrincipal(ci);

                // Attach the CustomPrincipal to HttpContext.User and Thread.CurrentPrincipal
                HttpContext.Current.User = prin;
                Thread.CurrentPrincipal = prin;
            }
        }

        
    }
}