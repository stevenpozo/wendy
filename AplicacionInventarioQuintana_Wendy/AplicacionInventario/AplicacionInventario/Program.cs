using AplicacionInventario.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<usuariosinventarioContext>(options =>
 options.UseMySql(builder.Configuration.GetConnectionString("conexion1"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.17-mysql")));

builder.Services.AddDbContext<inventarioContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("conexion2"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.17-mysql")));

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
