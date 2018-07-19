using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Ts.IO.JsonSerialization;
using Ts.Solver;
using TsWebApp.Controllers;
using TsWebApp.Data;
using TsWebApp.Services;

namespace TsWebApp {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {

            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production") {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString(""))
                );
            }
            else {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase()
                );
            }

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            JsonConvert.DefaultSettings = GetSerializerSettings;

            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });

            services.AddSingleton<Solver>();
            services.AddTransient<EventService>();
            services.AddSingleton<ConversionService>();
            services.AddSingleton<FormResolver>();
            services.AddSingleton<TextViewService>();
            services.AddSingleton<SvgViewService>();
            services.AddTransient<TsController>();

            services
                .AddMvc()
                .AddJsonOptions(JsonSetup)
                .AddRazorPagesOptions(options => {
                    options.Conventions.AddPageRoute("/Tableau/TableauRequest", string.Empty);
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            } else {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseAuthentication();

            app.UseMvc();
        }

        private static void JsonSetup(MvcJsonOptions options) {

            var serializerSettings = GetSerializerSettings();

            options.SerializerSettings.SerializationBinder = serializerSettings.SerializationBinder;
            options.SerializerSettings.TypeNameHandling = serializerSettings.TypeNameHandling;
            options.SerializerSettings.Formatting = serializerSettings.Formatting;
        }

        private static JsonSerializerSettings GetSerializerSettings() {

            return new JsonSerializerSettings() {
                SerializationBinder = new TableauJsonBinder(),
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.None
            };
        }
    }
}
