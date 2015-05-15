using System.Linq;
using System.Web.Mvc;
using CardSite1.Abstract;
using CardSite1.Infrastructure;
using CardSite1.Models;
using CardSite1.Filters;

namespace CardSite1.Controllers
{
    [Culture]
    [PageAuthorize(Roles="Admin")]
    public class AdminController : Controller
    {
        public IUserRepository repository;

        public AdminController(IUserRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.Users);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.DeleteUser(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult BlockUser(int id)
        {
            repository.BlockUser(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UnBlockUser(int id)
        {
            repository.UnBlockUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            UserModel user = repository.Users.FirstOrDefault(n => n.Id == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            repository.SaveChanges(user);
            return RedirectToAction("Index");
        }
    }
}