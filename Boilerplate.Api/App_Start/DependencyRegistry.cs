using Autofac;
using Autofac.Integration.WebApi;
using Boilerplate.Business;
using Boilerplate.EFCore;
using Boilerplate.EFCore.Data;
using Boilerplate.EFCore.EFComplexServices;
using Boilerplate.Shared.Entities;
using System.Reflection;
using System.Web.Http;

namespace Boilerplate.CMS
{
    public class DependencyRegistry
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();
                

            // Đăng ký DbContext
            RegisterDbContext(builder);

            // Đăng ký Complex repository and services
            RegisterComplexRepo(builder);

            // Đăng ký Businesses
            RegisterBusinesses(builder);

            // Đăng ký DataRepositories
            RegisterDataRepo(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterBusinesses(ContainerBuilder builder)
        {
            // Đăng ký Businesses
            builder.RegisterType<UserBusiness>().As<IUserBusiness>();
        }

        private static void RegisterDataRepo(ContainerBuilder builder)
        {
            // Đăng ký DataRepositories
            builder.RegisterType<DataRepository<User>>().As<IDataRepository<User>>();
        }

        private static void RegisterComplexRepo(ContainerBuilder builder)
        {
            // Đăng ký ComplexRepository
            builder.RegisterType<ComplexRepository>().As<IComplexRepository>();

            // Đăng ký Complex services
            builder.RegisterType<ComplexUserServices>().As<IComplexUserServices>();
        }

        private static void RegisterDbContext(ContainerBuilder builder)
        {
            builder.RegisterType<BoilerplateDbContext>().As<IBoilerplateDbContext>()
                .WithParameter("connectionString", "Default")
                .InstancePerLifetimeScope();
        }
    }
}