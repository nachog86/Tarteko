using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Net.Http;
using ClienteBlazor.Service;
using System.Threading.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Configura los servicios
builder.Services.AddScoped(sp => 
    new HttpClient 
    { 
        BaseAddress = new Uri("http://localhost:5272") 
    });

// Registro de otros servicios
// builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<IInmuebleService, InmuebleService>();

await builder.Build().RunAsync();


