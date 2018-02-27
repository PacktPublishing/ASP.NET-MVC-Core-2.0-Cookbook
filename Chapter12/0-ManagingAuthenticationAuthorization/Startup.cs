using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
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
            services.AddAuthorization(auth => auth.AddPolicy("AuthPolicyAuthentication", policy => policy.RequireAuthenticatedUser()));

            services.AddAuthorization(auth => auth.AddPolicy("AuthPolicyAdminRole", policy => policy.RequireRole("AdminRole")));
            services.AddAuthorization(auth => auth.AddPolicy("AuthPolicyReviewerRole", policy => policy.RequireRole("ReviewerRole")));
            services.AddAuthorization(auth => auth.AddPolicy("AuthPolicySpecificClaim", policy => policy.RequireClaim("SpecificClaim")));

            services.AddMvc(config => {
                var authorizationPolicy = new AuthorizationPolicyBuilder()
                                             .RequireAuthenticatedUser()
                                             .Build();
                config.Filters.Add(new AuthorizeFilter(authorizationPolicy));
            });
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

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
