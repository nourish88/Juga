using Microsoft.AspNetCore.Builder;

namespace Framework.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        //middle ware ı apiye eklenebilecek hale getirdik.
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
