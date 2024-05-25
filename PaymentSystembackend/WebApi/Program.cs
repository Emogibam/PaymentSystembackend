using Application;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Seed;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PaymentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PaymentSystem", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the input below. \r\n\r\n Example :'Bearer 124fsfs' "
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
});


builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    x.Password.RequireUppercase = true;
    x.Password.RequiredLength = 8;
    x.Password.RequireDigit = false;
    x.SignIn.RequireConfirmedEmail = true;
})
                .AddEntityFrameworkStores<PaymentContext>()
                .AddDefaultTokenProviders();

builder.Services.AddMediatR(typeof(MediatREntrypoint).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// Inside your Main method or wherever you're resolving services
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<User>>();
        var dbContext = services.GetRequiredService<PaymentContext>();

        await Seeder.Seed(roleManager, userManager, dbContext);
    }
    catch (Exception ex)
    {
        // Log the exception or handle it appropriately
        Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    }
}
app.MapControllers();

app.Run();
