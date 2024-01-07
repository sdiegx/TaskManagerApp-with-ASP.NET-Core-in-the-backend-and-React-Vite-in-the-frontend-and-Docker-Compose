using BusinessLayer.Clases;
using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
// Conexion a las variables del archivo .env
var connection_string = System.Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el acceso a datos
// Crea una variable con la cadena de conexion. Esta linea lee el archivo appsettings.json
// var conn = builder.Configuration.GetConnectionString("AppConection"); 
// Esta linea hace la conexion con la base de datos. La variable connection_string toma la cadena
// de conexion del archivo .env
builder.Services.AddDbContext<DBDevelopmentAppContext>(x=>x.UseSqlServer(connection_string)); // Construye el contexto

// Configurar las interfaces para que el controlador las pueda usar
builder.Services.AddScoped<ITarea, LogicaTarea>();
builder.Services.AddScoped<IPersona, LogicaPersona>();
builder.Services.AddScoped<IProyecto, LogicaProyecto>();
builder.Services.AddScoped<ITareasProyecto, LogicaTareasProyecto>();

string _MyCors = "String-PolicyCors";

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: _MyCors,
        builder => builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    // Registra la solicitud en la consola.
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

    // Llama al siguiente middleware.
    await next();

    // Registra la respuesta en la consola.
    Console.WriteLine($"Response: {context.Response.StatusCode}");
});

app.UseCors(_MyCors); // Aplicar la pol�tica CORS aqu�

app.UseAuthorization();

app.MapControllers();

app.Run();
