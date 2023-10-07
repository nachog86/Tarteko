using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using CloudinaryDotNet;
using DotNetEnv;
using ServidorApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ServidorApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Cargar variables de entorno del archivo .env
Env.Load();

// Configuración de Cloudinary
var cloudinary = new Cloudinary();  // Esto usará CLOUDINARY_URL del entorno automáticamente
builder.Services.AddSingleton(cloudinary);

// Configuración de Entity Framework y PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"))
);

// Configuración de Autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY"))),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

// Otros servicios
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<JwtService>(sp => 
    new JwtService(Environment.GetEnvironmentVariable("JWT_SECRET_KEY"), Environment.GetEnvironmentVariable("JWT_EXP_DATE"))
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware para usar Autenticación y Autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
