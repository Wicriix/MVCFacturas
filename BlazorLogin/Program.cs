using BlazorLogin;
using IdentityModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<CustomAuthenticationMessageHandler>();
builder.Services.AddHttpClient("magic2", opt => opt.BaseAddress = new Uri("https://localhost:7267"))
    .AddHttpMessageHandler<CustomAuthenticationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("magic2"));

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://localhost:7267";
    options.ProviderOptions.ClientId = "magic2";
    options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("email");
    options.ProviderOptions.RedirectUri = "https://localhost:7194/signin-oidc";
    options.ProviderOptions.PostLogoutRedirectUri = "https://localhost:7194/signout-callback-oidc";
    options.ProviderOptions.ResponseType = OidcConstants.ResponseTypes.Code;
    options.ProviderOptions.ResponseMode = OidcConstants.ResponseModes.Query;

});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();

public class CustomAuthenticationMessageHandler : AuthorizationMessageHandler
{
    public CustomAuthenticationMessageHandler(IAccessTokenProvider provder, NavigationManager nav) : base(provder, nav)
    {
        ConfigureHandler(new string[] { "https://localhost:7267" });
    }
}
