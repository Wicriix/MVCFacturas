
using ServerAuthIdentity;
using ServerAuth.Data;
using ServerAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServerAuthIdentity.IDBInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationsDbContext>(options =>
options.UseSqlServer(
                    connectionString: builder.Configuration.GetConnectionString("IdentityServerConnection"),
                    sqlServerOptionsAction: sqlOpt =>
                    {
                        sqlOpt.CommandTimeout(7200);
                        sqlOpt.EnableRetryOnFailure();
                    }
                    )
);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().
    AddEntityFrameworkStores<ApplicationsDbContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IDBInitializer, DBInitializer>();
builder.Services.AddRazorPages();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
})
    .AddInMemoryIdentityResources(SD.GetIdentityResources())
    .AddInMemoryApiResources(SD.apiResources)
    .AddInMemoryApiScopes(SD.GetApiScopes())
    .AddInMemoryClients(SD.Clients())
    .AddAspNetIdentity<ApplicationUser>()
    .AddDeveloperSigningCredential();

builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
seedDatabase();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapRazorPages().RequireAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

void seedDatabase()
{
    using (var scoper = app.Services.CreateScope())
    {
        var dbIni = scoper.ServiceProvider.GetRequiredService<IDBInitializer>();
        dbIni.Initialize();
    }
}
