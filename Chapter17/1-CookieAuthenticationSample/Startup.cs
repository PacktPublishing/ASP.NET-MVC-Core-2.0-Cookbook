using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CookieAuthenticationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("CookieAuthenticationScheme")
                    .AddCookie("CookieAuthenticationScheme", options => {
                        options.LoginPath = "/Home/Login";
                        /*
                        Return Http 401, instead of redirection

                        options.Events.OnRedirectToLogin = (context) => {
                            context.Response.StatusCode = 401;
                			return Task.CompletedTask;
                        };
                        */
                    });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}
