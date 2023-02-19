using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.Material;
using Microsoft.JSInterop;
using Blazored.Modal;
using Microsoft.Extensions.Configuration;

namespace InvoicesBlazor
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services
            .AddBlazorise(options =>
            {
                options.ChangeTextOnKeyPress = true;
            })
            .AddMaterialProviders()
            .AddMaterialIcons();
            builder.Services.AddBlazoredModal();
            builder.Services.AddScoped(sp => new HttpClient());
            builder.Services.AddMsalAuthentication( opt =>
            {
                builder.Configuration.Bind("AzureAd", opt.ProviderOptions.Authentication);
                opt.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/openid");
            });
            await builder.Build().RunAsync();
        }
    }
}
