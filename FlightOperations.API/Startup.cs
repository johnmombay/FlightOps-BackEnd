using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FlightOperations.Model;
using FlightOperations.Services;
using FlightOperations.Services.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlightOperations.API
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();

            

            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Flight Operations API",
                    Description = "Flight Operations API Documentation by ODRTECHINC"
                });
            });

            //services.AddDbContext<FlightOperationsContext>(x => x.UseInMemoryDatabase("ODRDev_flightOps"));
            services.AddDbContext<FlightOperationsContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("FlightOperations")));

            services.AddMvc()
                   .AddJsonOptions(
                options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddMvc().AddJsonOptions(o => o.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None);

            services.AddAutoMapper();
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("appSettings");
            services.Configure<appSettings>(appSettingsSection);

            // configure jwt authentication
            var AppSettings = appSettingsSection.Get<appSettings>();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<ImaintenanceServices>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetUser(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            // configure DI for application services
            services.AddScoped<IaircraftServices, aircraftServices>();
            services.AddScoped<IflightscheduleServices, flightscheduleServices>();
            services.AddScoped<ImaintenanceServices, maintenanceServices>();
            services.AddScoped<IcommercialPlanningServices, commercialPlanningServices>();
            services.AddScoped<IflightOperationsServices, flightOperationsServices>();
            services.AddScoped<IcrewPlanningServices, crewPlanningServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight Operations API");
            });
        }
    }
}
