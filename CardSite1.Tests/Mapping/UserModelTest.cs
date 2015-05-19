using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardSite1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardSite1.Tests.Mapping
{
    [TestClass]
    public class UserModelTest
    {
        [TestMethod]
        public void UserModelAddressTest()
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            using (var context = new Context())
            {
                context.Database.Create();
                UserModel user = new UserModel
                {
                    FirstName = "Kate",
                    LastName = "Shunkevich",
                    Post = "CEO",
                    Place = "MyCompany",
                    Addresses = new List<AddressModel>
                    {
                        new AddressModel
                        {
                            Address = "Vitebsk city",
                            Comment = "HomePlace"
                        },
                        new AddressModel
                        {
                            Address = "Minsk city",
                            Comment = "StudyPlace"
                        }
                    }
                };
                context.Entry(user).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
