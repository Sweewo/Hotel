using System;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Hotel.Application.Commands.Bookings.CreateBooking;
using Hotel.Application.Infrastructure;
using Hotel.Application.Infrastructure.ApiClients.Users;
using Hotel.Application.Infrastructure.AutoMapper;
using Hotel.Application.Infrastructure.ImageWriter;
using Hotel.Application.Interfaces;
using Hotel.Application.Interfaces.ApiClients.Users;
using Hotel.Application.Interfaces.ImageWriter;
using Hotel.Common;
using Hotel.Infrastructure;
using Hotel.Persistance;
using Hotel.Web.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Hotel.Web.Api
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
            services.Configure<SettingsModel>(Configuration.GetSection("Settings"));
            var serviceProvider = services.BuildServiceProvider();

            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IUserApiService, UserApiService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IImageWriter, GoogleCloudImageWriter>();

            // Add MediatR
            services.AddMediatR(typeof(CreateBookingCommand).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Add DbContext using MySQL Server Provider
            services.AddDbContext<IHotelDbContext, HotelDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("HotelDatabase")));

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateBookingCommand>());

            // Add jwt token auth
            var sharedKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(serviceProvider.GetService<IOptions<SettingsModel>>().Value.TokenSigningKey));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Events = new JwtBearerEvents
                   {
                       OnTokenValidated = context =>
                       {
                           var claims = context.Principal.Claims;

                           return Task.CompletedTask;
                       }
                   };
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       RoleClaimType = "authorities",
                       IssuerSigningKey = sharedKey,
                       RequireSignedTokens = true,
                       ValidateAudience = false,
                       ValidateIssuer = false,
                       ClockSkew = TimeSpan.Zero
                   };
               });

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseMvc();
        }
    }
}
