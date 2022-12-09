using AutoMapper;
using Dental_CLinic.BAl;
using Dental_CLinic.BAl.Models;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string ConnectionString = builder.Configuration.GetConnectionString("DentalClinic");

// to use UseSqlServer Should Intall Microsoft.tools
builder.Services.AddDbContext<ApplicationDbContxt>
    (options => options.UseSqlServer(ConnectionString));


builder.Services.AddIdentity<IdentityUserExtend,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContxt>();
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "Account/LogIn";
    options.AccessDeniedPath = "Account/AccessDenied";
    options.SlidingExpiration = true;
});
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddTransient<ICounrtyService, CountryService>();
builder.Services.AddTransient<ICityService, CityService>();

builder.Services.AddTransient<IRegionService, RegionService>();

builder.Services.AddLocalization(options => options.ResourcesPath = "Languages");

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
var supportedCultures = new[] { "en-US", "ar-EG" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[1])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

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
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();


app.UseAuthorization();
app.UseRequestLocalization(localizationOptions);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Registration}/{id?}");

app.Run();
