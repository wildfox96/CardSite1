using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardSite1.Infrastructure
{
    public class PageAuthorizeAttribute : AuthorizeAttribute
    {
        private string[] allowedUsers = new string[] { };
        private string[] allowedRoles = new string[] { };

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!String.IsNullOrEmpty(Users))
            {
                allowedUsers = Users.Split(',');
                for (int i = 0; i < allowedUsers.Length; i++)
                {
                    allowedUsers[i] = allowedUsers[i].Trim();
                }
            }
            if (!String.IsNullOrEmpty(Roles))
            {
                allowedRoles = Roles.Split(',');
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    allowedRoles[i] = allowedRoles[i].Trim();
                }
            }
            return AuthoriseData.IsAuthenticated(httpContext) && Role(httpContext) && User(httpContext);
        }

        private bool User(HttpContextBase httpContext)
        {
            if (allowedUsers.Length > 0)
                return allowedUsers.Contains(AuthoriseData.GetEmail(httpContext));
            return true;
        }

        private bool Role(HttpContextBase httpContext)
        {
            if (allowedRoles.Length > 0)
                return allowedRoles.Contains(AuthoriseData.GetRole(httpContext));
            return true;
        }
    }
}