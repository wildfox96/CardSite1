using System;
using System.Linq;
using System.Web;
using CardSite1.Abstract;
using CardSite1.Concrete;
using CardSite1.Models;

namespace CardSite1.Infrastructure
{
    public class AuthoriseData
    {
        private static IUserRepository repository = new UserRepository();

        public static void LogIn(HttpContextBase httpContext, string userCookie)
        {
            var cookie = new HttpCookie("AUTH")
            {
                Value = userCookie,
                Expires = DateTime.Now.AddYears(1)
            };
            httpContext.Response.Cookies.Add(cookie);
        }

        public static void LogOff(HttpContextBase httpContext)
        {
            var cookie = new HttpCookie("AUTH")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            httpContext.Response.Cookies.Add(cookie);
        }

        public static UserModel GetUserByCookie(string authCookie)
        {
            return repository.Users.FirstOrDefault(e => e.Cookie == authCookie);
        }

        public static bool IsAuthenticated(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies["AUTH"];
            if (authCookie != null)
            {
                UserModel user = GetUserByCookie(authCookie.Value);
                return user != null;
            }
            return false;
        }

        public static string GetRole(HttpContextBase context)
        {
            var authCookie = context.Request.Cookies["AUTH"];
            if (authCookie != null)
            {
                UserModel user = GetUserByCookie(authCookie.Value);
                return repository.Roles.First(m => m.Id == user.RoleId).RoleName;
            }
            return null;
        }

        public static string GetEmail(HttpContextBase context)
        {
            var authCookie = context.Request.Cookies["AUTH"];
            return authCookie != null ? GetUserByCookie(authCookie.Value).Email : null;
        }

        public static int GetUserId()
        {
            var httpCookie = HttpContext.Current.Request.Cookies.Get("AUTH");
            if (httpCookie != null)
            {
                var cookies = httpCookie.Value;
                UserModel user = GetUserByCookie(cookies);
                return user.Id;
            }
            return 0;
        }
    }
}