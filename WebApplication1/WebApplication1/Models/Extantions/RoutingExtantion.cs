using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.MiddlewareModels;

namespace WebApplication1.Models.Extantions
{
    public static class RoutingExtantion
    {
        public static IApplicationBuilder UseRouteToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutingMiddleware>();
        }
    }
}
