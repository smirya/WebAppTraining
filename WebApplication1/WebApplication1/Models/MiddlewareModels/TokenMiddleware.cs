using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.MiddlewareModels
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private string _pattern;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public TokenMiddleware(RequestDelegate next, string pattern) : this(next)
        {
            _pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];

            if (token != _pattern)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid!");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
