
using AutoMapper;
using Booking.Api.Middlewares;
using Booking.Application.Common.Mappings;
using Booking.Application.Reservations.Commands;
using Booking.Infrastructure;
using Booking.Infrastructure.Common;
using Booking.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
namespace Booking.Api
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var builder = WebApplication.CreateBuilder(args);

    //        // Add services to the container.
    //        builder.Services.ConfigureInfrastructure(builder.Configuration);
    //        builder.Services.AddControllers();
    //        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    //        builder.Services.AddOpenApi();
    //        builder.Services.AddCors(options =>
    //        {
    //            options.AddPolicy("AllowAll", policy =>
    //            {
    //                policy
    //                    .AllowAnyOrigin()
    //                    .AllowAnyMethod()
    //                    .AllowAnyHeader();
    //            });

    //            options.AddPolicy("AllowTrusted", policy =>
    //            {
    //                var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

    //                policy.WithOrigins(allowedOrigins)
    //                      .AllowAnyMethod()
    //                      .AllowAnyHeader()
    //                      .AllowCredentials() // For cookies
    //                      .WithHeaders("Authorization", "Content-Type", "X-Requested-With", "x-signalr-user-agent", "x-negotiateversion");
    //            });

    //        });
    //        var app = builder.Build();

    //        // Configure the HTTP request pipeline.
    //        if (app.Environment.IsDevelopment())
    //        {
    //            app.MapOpenApi();
    //            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
    //        }

    //        app.UseCors(builder.Configuration["Cors:Policy"] ?? "AllowAll");
    //        app.UseAuthentication();
    //        app.UseAuthorization();
    //        app.MapControllers();

    //        app.Run();
    //    }
    //}
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.ConfigureInfrastructure(builder.Configuration);
            builder.Services.PostConfigure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Events ??= new JwtBearerEvents();

                var originalOnMessageReceived = options.Events.OnMessageReceived;

                options.Events.OnMessageReceived = async context =>
                {
                    var accessToken = context.Request.Query["access_token"];
                    var path = context.HttpContext.Request.Path;

                    if (!string.IsNullOrEmpty(accessToken) &&
                        (path.StartsWithSegments("/hubs/chat") || path.StartsWithSegments("/hubs/notification")))
                    {
                        context.Token = accessToken;
                    }
                    else if (originalOnMessageReceived != null)
                    {
                        await originalOnMessageReceived(context);
                    }
                };
            });

            builder.Services.AddControllers();

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddOpenApi();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });

                options.AddPolicy("AllowTrusted", policy =>
                {
                    var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials() // For cookies
                          .WithHeaders("Authorization", "Content-Type", "X-Requested-With", "x-signalr-user-agent", "x-negotiateversion");
                });

            });
            //builder.Services.AddMediatR(typeof(CreateReservationCommandHandler).Assembly);
            //builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            var app = builder.Build();
            app.UseMiddleware<GlobalExceptionHandler>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || true)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking API v1");
                });

            }

            app.UseCors(builder.Configuration["Cors:Policy"] ?? "AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
