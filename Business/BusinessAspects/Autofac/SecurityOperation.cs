using System;
using Castle.DynamicProxy;
using Framework.Extensions;
using Framework.Utilities.Interceptors.Autofac;
using Framework.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{//authorizationu api de değil de burada yaptık.
    public class SecurityOperation:MethodInterception
   {
       private string[] _roles;
       private IHttpContextAccessor _httpContextAccessor;

       public SecurityOperation(string roles)
       {
           _roles = roles.Split(',');
           _httpContextAccessor=ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
       }

       protected override void OnBefore(IInvocation invocation)
       {
           var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
           foreach (var role in _roles)
           {
               if (roleClaims.Contains(role))
               {
                   return;
               }
               throw new Exception("Yetkisiz işlem");
           }
       }
    }
}
