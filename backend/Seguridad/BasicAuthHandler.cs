using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace backend.Seguridad
{
    public class BasicAuthHandler
    {
        public readonly RequestDelegate _next;
        public readonly string _realm;
        public readonly IConfiguration _config;

        public BasicAuthHandler(RequestDelegate next, string realm, IConfiguration config)
        {
            _next = next;
            _realm = realm;
            _config = config;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized request");
                return;
            }

            var authHeader = context.Request.Headers["Authorization"];
            var appKey = _config.GetValue<string>("AppKey");

            if (authHeader != appKey)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized request");
                return;
            }
            await _next(context);
        }

    }
}
