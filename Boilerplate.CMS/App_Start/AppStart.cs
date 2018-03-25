namespace Boilerplate.CMS.App_Start
{
    public class AppStart
    {
        public static void StartupApplication()
        {
            // Register dependencies
            DependencyRegistry.RegisterDependencies();
        }
    }
}