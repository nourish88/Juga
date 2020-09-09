using Framework.CrossCuttingConcerns.Caching;
using Framework.CrossCuttingConcerns.Caching.MemoryCache;
using Framework.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.DependencyResolvers
{
    public class FrameWorkModule:IFrameWorkModule
    {// tüm resolve işlemlerini tek ir merkezden yönetiyoruz. Gayet güzel.
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
        }
    }
}
