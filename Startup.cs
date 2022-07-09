using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VerifyMeIntegration.Data;
using VerifyMeIntegration.Data.Repo;
using VerifyMeIntegration.Dtos;
using VerifyMeIntegration.Helpers;

namespace VerifyMeIntegration
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

            services.AddDbContext<VerifyMeDataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SQLConnection")
                , builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                }));
            services.AddCors();
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VerifyMeIntegration", Version = "v1" });
            });
            string authority = Configuration.GetSection("AppSettings").GetSection("Authority").Value;
            string audience = Configuration.GetSection("AppSettings").GetSection("Audience").Value;

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = authority;
                    options.RequireHttpsMetadata = false;

                    options.Audience = audience;
                });
            services.AddScoped<ICacheService, CacheService>();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IHelper, Helper>();
            services.Configure<PricingList>(Configuration.GetSection("AppSettings:Pricing"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VerifyMeIntegration v1"));
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
