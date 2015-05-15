using System;
using System.Web.Mvc;
using System.Web.Routing;
using CardSite1.Abstract;
using CardSite1.Concrete;
using Ninject;

namespace CardSite1.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) kernel.Get(controllerType);
        }

        public void AddBindings()
        {
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRegistrationConfirmation>().To<RegistrationConfirmation>();
        }
    }
}