using Autofac;
using Farmino.Infrastructure.ImageManager.Interface;
using System.Reflection;

namespace Farmino.Infrastructure.IoC
{
    public class ImageManagmentModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ImageManagmentModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IImageManager>())
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
