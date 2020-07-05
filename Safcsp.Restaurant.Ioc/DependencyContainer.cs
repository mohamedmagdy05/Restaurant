using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Safcsp.Restaurant.Application.Common;
using Safcsp.Restaurant.Application.Extensions;
using Safcsp.Restaurant.Application.Interfaces;
using Safcsp.Restaurant.Application.Services;
using Safcsp.Restaurant.Domain.Entities;
using Safcsp.Restaurant.Domain.Interfaces;
using Safcsp.Restaurant.Infrastructure;
using Safcsp.Restaurant.Ioc.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safcsp.Restaurant.Ioc
{
    public class DependencyContainer
    {
        /// <summary>
        /// inversion of control using it for dependency injection 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void RegisterService(IServiceCollection services, IConfiguration Configuration)
        {
            // Add Database sql server  Context 
            services.AddDbContext<RestaurantDbContext>(d => d.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection")));
            services.AddScoped<RestaurantDbContext>();

            services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<User, Role>>()
                .AddEntityFrameworkStores<RestaurantDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
            });



            services.AddTransient<IRepositoryWrapper, RepositoryWrapper>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IReservationRepository, ReservationRepository>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IReservationService, ReservationService>();


            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    // add a custom operation filter which sets default values
                    options.OperationFilter<SwaggerDefaultValues>();
                    options.DocumentFilter<OperationsOrderingFilter>();
                    options.EnableAnnotations();
                    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT containing userid claim",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                    });
                    var security =
                        new OpenApiSecurityRequirement
                        {
                        {
                         new OpenApiSecurityScheme
                        {
                         Reference = new OpenApiReference
                        {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                         },
                         UnresolvedReference = true
                            },
                            new List<string>()
        }
                        };
                    options.AddSecurityRequirement(security);

                    //var filePath = Path.Combine(System.AppContext.BaseDirectory, "DatingAppCleanArch.API.xml");
                    //options.IncludeXmlComments(filePath);
                });
        }
    }
}
