using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using WebbutvecklingLABB2.Client;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebbutvecklingLABB2.Client.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Lägg till HttpClient för att kunna anropa API:et
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();