using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.MiddlewareModels
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();

            switch(path)
            {
                case "/index": await context.Response.WriteAsync("Home page"); break;
                case "/about": await context.Response.WriteAsync("About page"); break;
                default: context.Response.StatusCode = 404; break;
            }
                
        }
    }
}
