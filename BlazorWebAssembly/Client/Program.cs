using BlazorWebAssembly.Client;
using BlazorWebAssembly.Shared.CapaServices.BusinessLogic.ClientServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Ignora el Certificado SSL (https) SI NO EXISTE
//var httpClientHandler = new HttpClientHandler();
//httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

builder.Services.AddScoped(sp => new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddSingleton(sp => new HttpClient(httpClientHandler) { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Inyección de Dependencias
builder.Services.AddScoped<IPersona, RPersona>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
