using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace HotelRooms_REST_EF.Backend.Middlewares
{
    public class MyErrorHandlingMiddleware : IMiddleware
    {
        public MyErrorHandlingMiddleware()
        {
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next?.Invoke(context);
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Upss");
            }
        }
    }
}