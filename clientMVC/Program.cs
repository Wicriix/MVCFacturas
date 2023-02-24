using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "oidc";
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    //.AddCookie(options => { 
    //    options.Cookie.HttpOnly = true;
    //    options.ExpireTimeSpan= TimeSpan.FromMinutes(30);
    //    options.LoginPath = "/Auth/Login";
    //    options.SlidingExpiration = true;

    //})
    .AddOpenIdConnect("oidc",options => {
        options.Authority = builder.Configuration["ServiceUrl:IdentityApi"];
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "magic";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
        options.UsePkce = true; 
        options.ResponseMode = "query";
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("magic");
        options.SaveTokens = true;

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
