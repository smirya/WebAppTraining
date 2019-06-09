using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models.MiddlewareModels;
using WebApplication1.Controllers;
using WebApplication1.Models.Extantions;

namespace WebApplication1
{
    public class Startup
    {
        IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if(_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.MapWhen(context =>
            {
                return context.Request.Query.ContainsKey("id") &&
                       context.Request.Query["id"] == "7";
            }, HomeController.HandlId);

            app.UseMiddleware<TokenMiddleware>();

            app.UseRouteToken();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page not found!");
            });
        }

        
    }
}
