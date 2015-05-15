using System.Linq;
using System.Web.Mvc;
using CardSite1.Abstract;
using CardSite1.Infrastructure;
using CardSite1.Models;
using CardSite1.Filters;

namespace CardSite1.Controllers
{
    [Culture]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IUserRepository repository;
        private IRegistrationConfirmation confirmation;

        public AccountController(IUserRepository repository, IRegistrationConfirmation confirmation)
        {
            this.repository = repository;
            this.confirmation = confirmation;
        }

        public ActionResult Index(UserModel user)
        {
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel registration)
        {
            if (ModelState.IsValid)
            {
                if (!repository.UserExists(registration.LoginName, registration.Email))
                {
                    repository.RegisterUser(registration);
                    confirmation.SendConfirmationLetter(registration);
                    return View("ConfirmRegistration", registration);
                }
                ModelState.AddModelError("", Resources.Resource.User_already_exist);
                return View();
            }
            ModelState.AddModelError("", Resources.Resource.Incorrect_data);
            return View(registration);
        }

        public ActionResult Verify(string id)
        {
            if (string.IsNullOrEmpty(id))
                return View("Error");
            UserModel user = repository.Users.FirstOrDefault(n => n.Cookie == id);
            if (user != null)
            {
                user.IsConfirmed = true;
                repository.SaveChanges(user);
                return View("Login");
            }
            return View("Error");
        }

        public ActionResult ConfirmRegistration(RegistrationModel registration)
        {
            return View(registration);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserModel user = repository.GetUser(login);
                if (user != null)
                {
                    if (user.IsConfirmed)
                    {
                        AuthoriseData.LogIn(HttpContext,user.Cookie);
                        string role = repository.Roles.First(n => n.Id == user.RoleId).RoleName;
                        if (role.ToCharArray().First() == 'B')
                            return View("Blocked");
                        return RedirectToAction("Index",role);
                    }
                    return View("NotConfirmed");
                }
                ModelState.AddModelError("", Resources.Resource.Incorrect_login_or_password);
                return View();
            }
            ModelState.AddModelError("", Resources.Resource.Incorrect_data);
            return View();
        }

        public ActionResult LogOff()
        {
            AuthoriseData.LogOff(HttpContext);
            return RedirectToAction("Index","Home");
        }
    }
}