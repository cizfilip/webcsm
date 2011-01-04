using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webcsm
{
    public class WebcsmIdentity : System.Security.Principal.IIdentity
    {
        private System.Web.Security.FormsAuthenticationTicket ticket;

        public WebcsmIdentity(System.Web.Security.FormsAuthenticationTicket ticket)
        {
            this.ticket = ticket;
        }

        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "Webcsm"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return ticket.Name; }
        }

        #endregion

        public string Email
        {
            get { return ticket.UserData; }
        }
    }

    public class WebcsmPrincipal : System.Security.Principal.IPrincipal
    {
        private WebcsmIdentity identity;
        
        public WebcsmPrincipal(WebcsmIdentity identity)
        {
            this.identity = identity;
        }

        #region IPrincipal Members

        public System.Security.Principal.IIdentity Identity
        {
            get { return identity; }
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        #endregion
    }

}