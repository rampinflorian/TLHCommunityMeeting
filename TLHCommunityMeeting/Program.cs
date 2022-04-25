using System.Globalization;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using TLHCommunityMeeting.Data;
using TLHCommunityMeeting.Services.StrawPoll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = "";

#if DEBUG 
connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

#else
connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
#endif

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    if (connectionString != null) options.UseSqlServer(connectionString);
});


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<StrawPollService>();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

const string defaultDateCulture = "fr-FR";
var ci = new CultureInfo(defaultDateCulture)
{
    NumberFormat =
    {
        NumberDecimalSeparator = ".",
        CurrencyDecimalSeparator = "."
    }
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ci),
    SupportedCultures = new List<CultureInfo>
    {
        ci,
    },
    SupportedUICultures = new List<CultureInfo>
    {
        ci,
    }
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();