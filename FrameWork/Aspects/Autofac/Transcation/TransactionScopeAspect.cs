using System;
using System.Transactions;
using Castle.DynamicProxy;
using Framework.Utilities.Interceptors.Autofac;

namespace Framework.Aspects.Autofac.Transcation
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (var transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    transactionScope.Complete();
                    throw;
                }
            }
        }
    }
}
