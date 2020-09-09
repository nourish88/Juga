using Castle.DynamicProxy;
using Framework.CrossCuttingConcerns.Caching;
using Framework.Utilities.Interceptors.Autofac;
using Framework.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {// yeni bir data eklenip çıkarıldığında
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}