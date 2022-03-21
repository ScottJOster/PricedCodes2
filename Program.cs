using Microsoft.EntityFrameworkCore;
using PricedCodes2Project.ApplicationService;
using PricedCodes2Project.DataAccess.Context;
using PricedCodes2Project.PostcodePositionService;
using PricedCodes2Project.PropertyInfoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>
   (o =>
   {//strings removed
       o.UseSqlServer(connectionString: );
   });
builder.Services.AddScoped<IPostCodePositionService, PostcodePositionService>();
builder.Services.AddScoped<IPropertyInfoService, PropertyInfoService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();        

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
