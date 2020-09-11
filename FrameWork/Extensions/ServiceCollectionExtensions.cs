using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Framework.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Extensions
{
    //.Net core daki serviceleri merkezi leştiriyoruz
    /// <summary>
    /// Her katmanın çözümleme modülleri IServiceCollection'a ekleniyor.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="modules"></param>
    /// <returns></returns>
    public static class ServiceCollectionExtensions
    {
        private static IContainer _container;
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, IFrameWorkModule[] modules)
        {
            foreach (var module  in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
        /// <summary>
        /// Daha önce IServiceCollection tarafında yapılan çözümlemeleri dolduruyor.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules"></param>
        /// <returns></returns>
        public static IServiceCollection AddAutofacDependencyResolvers(this IServiceCollection services, Module[] modules)
        {

            var builder = new ContainerBuilder();
            builder.Populate(services);

            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }

            _container = builder.Build();

            return services;
        }

        public static IServiceProvider CreateAutofacServiceProvider(this IServiceCollection services)
        {
            return new AutofacServiceProvider(_container);
        }
    }
}
