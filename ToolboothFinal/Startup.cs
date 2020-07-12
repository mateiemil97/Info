using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Controllers;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.AuthenticationRepo;
using Repository.HistoryRepo;
using Repository.PriceRepo;
using Services.AuthenticationService;
using Services.CategoryService;
using Services.HistoryService;
using Services.LocationService;
using Services.PriceService;
using Services.TollBoothService;
using SqlDatabase;

namespace ToolboothFinal
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

            var assembly = Assembly.Load("Controllers");
            services.AddMvc().AddApplicationPart(assembly).AddControllersAsServices();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ToolboothContext>(connection =>  connection.UseSqlServer(Configuration.GetConnectionString("Connection")));
            
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IGenericRepository<Location>, GenericRepository<Location>>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped<IToolboothService, ToolboothService>();

            services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IPriceRepository, PriceRepository>();

            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IHistoryService, HistoryService>();

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            var mappingConfig = new MapperConfiguration(a => {
               a.AddProfile(new MapperClass());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddDefaultIdentity<User>().AddEntityFrameworkStores<ToolboothContext>();
            var jwtKey = Encoding.UTF8.GetBytes(Configuration.GetValue<string>("ApplicationSettings:JWT_Secret"));

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            });

            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,  
                    RequireExpirationTime = true
                };
            });


            services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors("cors");
            app.UseMvc();
        }
    }
}
