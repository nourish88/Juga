using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Framework.CrossCuttingConcerns.Caching;
using Framework.Utilities.Interceptors.Autofac;
using Framework.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Aspects.Autofac.Caching
{
   public class CacheAspect:MethodInterception
   {
       private int _duration;
       private ICacheManager _cacheManager;
        public CacheAspect(int duration=60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();// ICacheManageri getir..
        }


        public override void Intercept(IInvocation invocation)
        {//ilki class ismi ikinci metod ismi
            var methodName = string.Format($"{invocation.Method.ReturnType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();//parametreler
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            // dolaysıyla parametreli haline kadar metodları cachekeyebiliyoruz örnek
            //ProductManager.GetbyCategory(1)

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
            }
            invocation.Proceed();// metodu çalıştır
            _cacheManager.Add(key,invocation.ReturnValue,_duration);
            //sonucu cache e döndür.
        }
    }
}
