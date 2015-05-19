using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CardSite1.Abstract;
using CardSite1.Infrastructure;
using CardSite1.Filters;
using CardSite1.Models;

namespace CardSite1.Controllers
{
    [Culture]
    [PageAuthorize(Roles = "User,Owner,Admin")]
    public class UserController : Controller
    {
        private IUserRepository userRepository;
        private Context context = new Context();

        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult AddContactInformation()
        //{
        //    userRepository.AddContactInformation(new UserModel());
        //    context.Users.ToList();
        //    return View();
        //}

        public ActionResult AddContactInformation()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AddContactInformation(UserModel model, AddressModel address)
        //{
            
        //        UserModel user = new UserModel
        //        {
        //            Id = AuthoriseData.GetUserId(),
        //            LastName = model.LastName,
        //            Post = model.Post,
        //            Place = model.Place,
        //            Addresses = new List<AddressModel>
        //            {
        //                new AddressModel
        //                {
        //                    UserId = AuthoriseData.GetUserId(),
        //                    Address = address.Address,
        //                    Comment = address.Comment
        //                }
        //            }
        //        };
        //        context.Entry(user).State=EntityState.Modified;
        //        context.SaveChanges();
            
        //    return View(model);
        //}

        [HttpPost]
        public ActionResult AddContactInformation(UserModel model, AddressModel address)
        {

            UserModel user = new UserModel
            {
                Id = AuthoriseData.GetUserId(),
                LastName = model.LastName,
                Post = model.Post,
                Place = model.Place,
                Addresses = new List<AddressModel>
                    {
                        new AddressModel
                        {
                            UserId = AuthoriseData.GetUserId(),
                            Address = address.Address,
                            Comment = address.Comment
                        }
                    }
            };
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();

            return View(model);
        }

    }
}