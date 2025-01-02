using AnalisisDeDatosBetekTienda.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Antes de cambiar a guid

builder.Services.AddControllers();

builder.Services.AddDbContext<tiendaContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"))

);

// cors

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Reemplaza con el origen de tu aplicación React
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//    });
//});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//cors
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ejemplo de API"));

app.Run();
//app.Run("http://0.0.0.0:5000");
