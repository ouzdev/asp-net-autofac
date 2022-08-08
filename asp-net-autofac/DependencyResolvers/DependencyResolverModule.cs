using AspNetAutofac.API.Models;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;

namespace AspNetAutofac.API.DependencyResolvers
{
    public class DependencyResolverModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<EfProductDal>().As<IProductDal>().InstancePerLifetimeScope();

        }
    }
}
