using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<IDataRepository, ProductRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMiddleware<MyMiddleware1>();
            app.UseMiddleware1();

            app.Map("/oneurlsegment", (appBuilder) =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Third Inline middleware before Handle \n");
                    await next.Invoke();
                    await context.Response.WriteAsync("Third Inline middleware after Handle \n");
                });
            });

            app.MapWhen(context => context.Request.Query.ContainsKey("q1"), (appBuilder) =>
            {
                appBuilder.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Fourth Inline middleware before Handle \n ");
                    await next.Invoke();
                    await context.Response.WriteAsync("Fourth Inline middleware after Handle \n ");
                });
            });

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("First Inline middleware before Handle\n");
                await next.Invoke();
                await context.Response.WriteAsync("First Inline middleware after Handle");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Run middleware \n");
            });
        }
    }
}
