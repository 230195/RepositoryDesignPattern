using Autofac;
using System.Reflection;
using Data.IocDataModule;

namespace Businesslogic.IocBusinessModule
{
    public class BusinessModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DataModule());

            //Register all service classes with respective interfaces
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            base.Load(builder);

        }
    }
}
