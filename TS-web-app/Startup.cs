using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Ts.App.Controllers;
using Ts.App.Data;
using Ts.App.Services;
using Ts.App.Utilities;
using Ts.IO;
using Ts.IO.JsonSerialization;

namespace Ts.App {

    public class Startup {

        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment) {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services) {

            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();

            if (HostingEnvironment.IsProduction()) {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TS-database"))
                );
            }

            if (HostingEnvironment.IsDevelopment()) {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("TS-database-dev"))
                );
            }
            else {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TS-database-test")
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

            services.AddSingleton<Solver.Solver>();
            services.AddSingleton<IFormulaFactory, FormulaFactory>();
            services.AddSingleton<TableauSolutionService>();
            services.AddTransient<EventService>();
            services.AddSingleton<ConversionService>();
            services.AddSingleton<FormResolver>();
            services.AddSingleton<TextViewService>();
            services.AddTransient<TsController>();
            services.AddSingleton<FormulaValidator>();

            services
                .AddSwaggerGen(swagger => {

                    swagger.SwaggerDoc("v1",
                        new Info {
                            Title = "Tableau solver API",
                            Version = "v1",
                            Contact = new Contact() {
                                Name = "Jakub Sykora",
                                Email = "jakubsykora@protonmail.com"
                            }
                        });

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    swagger.IncludeXmlComments(xmlPath);

                    swagger.SchemaFilter<TsControllerSwaggerSchema>();
                })
                .AddSession()
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
            app.UseSwagger();
            app.UseSwaggerUI(swagger => swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Tableau solver API"));
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
