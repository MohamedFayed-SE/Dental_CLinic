using AutoMapper;
using Dental_CLinic.BAl;
using Dental_CLinic.BLL.Interfaces;
using Dental_CLinic.BLL.Services;
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
