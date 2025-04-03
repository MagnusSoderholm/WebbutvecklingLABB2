
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebbutvecklingLABB2.Client;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Kontrollera att basadressen till API:et är korrekt
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7179/") });

await builder.Build().RunAsync();
