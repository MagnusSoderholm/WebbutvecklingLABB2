using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebbutvecklingLABB2.Client;
using System.Threading.Tasks;
using WebbutvecklingLABB2.Client.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

await builder.Build().RunAsync();

