using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KindergartenManagementSystem.Repositories;
using KindergartenManagementSystem.Data;
using KindergartenManagementSystem.Services.EnterService;
using Microsoft.EntityFrameworkCore;
using KindergartenManagementSystem.Services;
using KindergartenManagementSystem.Filter.AbsenceFilter;


namespace KindergartenManagementSystem
{
    public class Startup
    {
        IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEatScoreRepository, EatScoreRepository>();
            services.AddAuthentication("Cookies")
                .AddCookie(option =>
                {
                    option.LoginPath = new PathString("/Login/Login");
                });

            services.AddDbContext<KindergartenMSContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IEnterDataService, EnterDataService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IAbsenceService, AbsenceService>();
            services.AddTransient<IMedicalRepository, MedicalRepository>();
            services.AddScoped<StudentAbsenceFilter>();
            services.AddScoped<TeacherAbsenceFilter>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
