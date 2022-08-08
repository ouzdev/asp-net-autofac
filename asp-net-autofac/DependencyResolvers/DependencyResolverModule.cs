using AspNetAutofac.API.Models;
using AspNetAutofac.API.Services;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace AspNetAutofac.API.DependencyResolvers
{
    public class DependencyResolverModule : Module
    {
        private readonly IConfiguration _configuration;

        public DependencyResolverModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<EfProductDal>().As<IProductDal>().InstancePerLifetimeScope();
            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"));
                return new AppDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();
        }
    }
}
