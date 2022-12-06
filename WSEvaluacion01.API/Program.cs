using WSEvaluacion01.Dominio.Persona;
using WSEvaluacion01.Infraestructura;
using WSEvaluacion01.Repositorio;
using WSEvaluacion01.Repositorio.Contexto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IPersonaInfraestructura, PersonaInfraestructura>();
builder.Services.AddTransient<IPersonaRepositorio, PersonaRepositorio>();
builder.Services.AddDbContext<BddEjercicioContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
