using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyShop.Domain.Abstract;
using MyShop.Domain.Concrete;
using MyShop.WebUI.Infrastructure.Abstract;
using MyShop.WebUI.Infrastructure.Concrete;
using Ninject;

namespace MyShop.WebUI.Infrastructure
{
    // реализация пользовательской фабрики контроллеров, 
    // наследуясь от фабрики используемой по умолчанию
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // получение объекта контроллера из контейнера 
            // используя его тип
            return controllerType == null
              ? null
              : (IController)_ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            _ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            _ninjectKernel.Bind<ICategoryRepository>().To<EFCategoryRepository>();
            _ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}