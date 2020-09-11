using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Framework.Utilities.Interceptors.Autofac;
using Framework.Utilities.Mappings;
using Framework.Utilities.Security.JWT;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{//resolve ettiğimiz yer
   public class AutofacBusinessModule:Module

    {


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NorthwindContext>();
            builder.RegisterType<AutoMapperHelper>();
            //repository nin resolvunu framework te servisleri Business ta resolve edebiliriz.
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As <IProductDal> ();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();



            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            //var dataAccess = Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(dataAccess)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces();
            //autofac dynamic proxy
            //Interceptor çalıştırır.
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions
            {
                Selector =  new AspectInterceptorSelector()
            }).SingleInstance();

        }
    }
}
