using Autofac;
using Autofac.Integration.Mvc;
using Boilerplate.Business;
using Boilerplate.EFCore;
using Boilerplate.EFCore.Data;
using Boilerplate.EFCore.EFComplexServices;
using Boilerplate.Shared.Entities;
using System.Web;
using System.Web.Mvc;

namespace Boilerplate.CMS
{
    public class DependencyRegistry
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());
            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Http context
            builder.RegisterInstance(new HttpContextWrapper(HttpContext.Current));

            
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
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
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