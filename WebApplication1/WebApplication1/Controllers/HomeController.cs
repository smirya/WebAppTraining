using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public static void Index(IApplicationBuilder builder)
        {
            builder.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }

        public static void About(IApplicationBuilder builder)
        {
            builder.Run(async context =>
            {
                await context.Response.WriteAsync("About");
            });
        }

        public static void HandlId(IApplicationBuilder builder)
        {
            builder.Run(async context =>
            await context.Response.WriteAsync("Id is aqual to 7!!!"));
        }
    }
}
