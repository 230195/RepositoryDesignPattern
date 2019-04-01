using Autofac;
using System.Reflection;
using Data.EntityFramework;
using Data.UnitOfWork;

namespace Data.IocDataModule
{
    public class DataModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assm = Assembly.GetExecutingAssembly();

            //For DB Context
            builder.RegisterType<TestDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
