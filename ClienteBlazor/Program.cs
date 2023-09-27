using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using ClienteBlazor.Data;
using Microsoft.EntityFrameworkCore;
using ClienteBlazor.Service;
using System.Threading.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configura los servicios
builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri("http://localhost:5272") 
    });


// Configura DbContext (Ajusta según tus necesidades)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de otros servicios
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<IInmuebleService, InmuebleService>();

await builder.Build().RunAsync();

