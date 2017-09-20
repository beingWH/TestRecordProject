using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestRecordProject.Domain.Abstract;
using TestRecordProject.Domain.Concrete;
using TestRecordProject.Domain.Entities;

namespace TestRecordProject.Infrastructure
{
    public class NinjectFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBinding();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBinding()
        {
            ninjectKernel.Bind<IRepository<Test>>().To<EFTestRepository>();
        }
    }
}