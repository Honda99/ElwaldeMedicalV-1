using ElwaldeEquipment;
using ElwaldeEquipment.Data;
using ElwaldeEquipment.Entities;
using ElwaldeEquipment.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IEquipmentsStore, JsonEquipmentsStore>();
builder.Services.AddSingleton<IPartnersStore, JsonPartnersStore>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddSingleton<IEmailSender, EmailSender>();


//var settings = new EmailSettings();
//builder.Configuration.Bind("EmailSettings", settings);
//builder.Services.AddSingleton(settings);

await builder.Build().RunAsync();
