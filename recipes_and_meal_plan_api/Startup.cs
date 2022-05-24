using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using recipes_and_meal_plan_api.Models;
using System;

namespace recipes_and_meal_plan_api
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

            services.AddControllers();

            services.AddDbContext<WeekDaysContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            services.AddDbContext<UnitsContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            services.AddDbContext<AdminUsersContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            services.AddDbContext<RecipeIngredientsContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            services.AddDbContext<IngredientsContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            services.AddDbContext<UsersContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
            services.AddDbContext<RecipeContext>(opt => opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 11))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
