using System;
using System.Collections.Generic;
using System.Text;
using Framework.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Extensions
{
  //.Net core daki serviceleri merkezi leştiriyoruz
    
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, IFrameWorkModule[] modules)
        {
            foreach (var module  in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
