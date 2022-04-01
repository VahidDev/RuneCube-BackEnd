using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repository.DAL;
using Repository.Mapper;
using Repository.Repository.Implementation;
using Repository.Services.Abstarction;
using RuneCube.DbSeeder;

namespace RuneCube
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<AppDbContext>(options=> {
                options.UseNpgsql(HerokuConnectionStringGetter.GetHerokuConnectionString(),builder=> {
                    builder.MigrationsAssembly(nameof(Repository));
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RuneCube", Version = "v1" });
            });
            services.AddCors((options) => {
                options.AddPolicy("",builder=> {
                    builder.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader();
                });
            });
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MapperProfile));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RuneCube v1"));
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.Seed();
            app.UseAuthorization();
            app.UseCors(o => {
                o.AllowAnyMethod().SetIsOriginAllowed(r => true).AllowCredentials();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
