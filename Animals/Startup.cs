using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AnimalsData.Entities;
using AnimalsService.Services;

namespace Animals
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=Animals.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<AnimalsContext>
                (options => options.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly("Animals")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAnimalTypeService, AnimalTypeService>();
            services.AddScoped<IPetVaccine, PetVaccineService>();
            services.AddScoped<IVaccine, VaccineService>();

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowAllOrigins");
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
