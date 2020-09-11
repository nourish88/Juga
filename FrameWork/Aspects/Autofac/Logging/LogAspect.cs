using System;
using System.Linq;
using Castle.DynamicProxy;
using Framework.CrossCuttingConcerns.Logging;
using Framework.CrossCuttingConcerns.Logging.Log4Net;
using Framework.Utilities.Interceptors.Autofac;

namespace Framework.Aspects.Autofac.Logging
{

    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerService;
        private bool _logOnAfter;
        public LogAspect(Type loggerType, bool logOnAfter)
        {
            if (loggerType.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception("Wrong Logger Type");

            _loggerService = (LoggerServiceBase)Activator.CreateInstance(loggerType);
            _logOnAfter = logOnAfter;
        }
        protected override void OnBefore(IInvocation invocation)
        {
        

            _loggerService.Error(GetLogDetail(invocation,"OnBefore"));
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (!_logOnAfter) return;

            _loggerService.Error(GetLogDetail(invocation, "OnAfter"));
            
        }

        LogDetail GetLogDetail (IInvocation invocation, string actionLog)
        {
            var logParameters = invocation.Arguments.Select(x => new LogParameter
            {
                Type = x.GetType().Name,
                Value = x
            }).ToList();

            var logDetail = new LogDetail
            {
                //ActionLog = actionLog,
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
