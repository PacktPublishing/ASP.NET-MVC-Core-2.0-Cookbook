using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace AuthenticationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var list = new[] {
                    new { Id=1, Title="Istanbul" },
                    new { Id=2, Title="New York" },
                    new { Id=3, Title="Madrid" },
                    new { Id=4, Title="Rome" },
                    new { Id=5, Title="Vienna" },
                };
                var json = JsonConvert.SerializeObject(list);

                context.Response.ContentType = "text/json";
                await context.Response.WriteAsync(json);
            });
        }
    }
}
