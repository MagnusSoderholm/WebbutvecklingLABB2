
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using WebbutvecklingLABB2.Client;


//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");

//// Kontrollera att basadressen till API:et är korrekt
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7179/") });

//await builder.Build().RunAsync();



using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebbutvecklingLABB2.Client;
using WebbutvecklingLABB2.Client.Services;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped<ApiService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7179/") });

await builder.Build().RunAsync();
