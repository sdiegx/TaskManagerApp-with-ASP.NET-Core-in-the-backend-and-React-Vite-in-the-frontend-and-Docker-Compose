using BackendAdmin.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
// Conexion a las variables del archivo .env
var connection_string = System.Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBDevelopmentAppContext>(options =>
// Esta linea de codigo que esta comentada toma la cadena de conexion del archivo appsettings.json
//options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
// Esta linea hace la conexion con la base de datos. La variable connection_string toma la cadena
// de conexion del archivo .env
options.UseSqlServer(connection_string));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
