using ApiCCV2.Data;
using ApiCCV2.Interfaces;
using ApiCCV2.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IEstudiante, EstudianteRepository>();
builder.Services.AddScoped<IProfesor, ProfesorRepository>();
builder.Services.AddScoped<IClase, ClaseRepository>();
builder.Services.AddScoped<IActividad, ActividadRepository>();
builder.Services.AddScoped<IActividadProfesor, ActividadProfesorRepository>();
builder.Services.AddScoped<IActividadEstudiante, ActividadEstudianteRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(7129); // HTTPS
    options.ListenAnyIP(5057); // HTTP
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.MapControllers();
app.Run("http://0.0.0.0:5057");
app.UseAuthorization();
app.UseCors(builder =>
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
app.MapControllers();

app.Run();
