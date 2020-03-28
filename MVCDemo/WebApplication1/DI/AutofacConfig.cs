using Autofac;
using Autofac.Integration.Mvc;
using MVCDemo.Configuration;
using System.Web.Mvc;
using MVCDemo.Repository;

namespace MVCDemo.DI
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            builder.RegisterType<TransactionDbContext>().As<ITransactionContext>();
            builder.RegisterType<CategoryDbContext>().As<ICategoryContext>();

            //Register Repositories
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}