using Front_To_Back_;
using Front_To_Back_.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt=>
     opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
    );


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    "default",
    "{controller=home}/{action=Index}/{id?}"
    );

app.Run();
