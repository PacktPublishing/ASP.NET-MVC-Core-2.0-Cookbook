using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FacebookGoogleAuthenticationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=FacebookGoogleAuthenticationSample;Data Source=."));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(o => o.LoginPath = new PathString("/home/login"))
                    .AddGoogle(google =>
                    {
                        google.ClientId = "1074523660996-lmhrgsuhau31ptca5ajln1334t94b4tj.apps.googleusercontent.com";
                        google.ClientSecret = "fW3fnRzs7DQa9WEUVbaMhCAL";
                    })
                    .AddFacebook(facebook =>
                    {
                        facebook.AppId = "208906605857885";
                        facebook.AppSecret = "90e620f09fbadfaa01f74e2bc32928d0";
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

            app.UseMvc((routes) =>
            {
                routes.MapRoute("SigninFacebook", "signin-facebook", new { controller = "Home", action = "FacebookOK" });
                routes.MapRoute("SigninGoogle", "signin-google", new { controller = "Home", action = "GoogleOK" });
                routes.MapRoute("Default", "{controller=Home}/{action=Index}");
            });
        }
    }
}
