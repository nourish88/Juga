using Castle.DynamicProxy;
using Framework.Utilities.Interceptors.Autofac;
using System.Diagnostics;
using Framework.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Aspects.Autofac.Performance
{
   
    public class PerformanceAspect:MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();// frameworkte resolve edebilmek için ServiceTool kullanmak gerekiyorö
        }

        protected override void OnAfter(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            string logLine = string.Format($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} --> {_stopwatch.Elapsed.TotalSeconds}");
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                //if (_loggerService != null)
                //{
                //    _loggerService.Log();
                //    return;
                //}
                Debug.WriteLine(logLine);
            }
            _stopwatch.Reset();
        }
    }
}
