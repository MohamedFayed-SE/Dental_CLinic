using AutoMapper;
using Dental_CLinic.BAl;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string ConnectionString = builder.Configuration.GetConnectionString("DentalClinic");

// to use UseSqlServer Should Intall Microsoft.tools
builder.Services.AddDbContext<ApplicationDbContxt>
    (options => options.UseSqlServer(ConnectionString));

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

app.UseRouting();


app.UseAuthorization();
app.UseRequestLocalization(localizationOptions);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
