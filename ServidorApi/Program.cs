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

// Otros servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
