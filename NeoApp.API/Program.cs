using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;
using NeoApp.API.Repositories;
using NeoApp.API.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ControleConsultaContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:DataBase"))
);

builder.Services.AddScoped<IConsultaRepositorie, ConsultaRepositorie>();
builder.Services.AddScoped<IMedicoRepositorie, MedicoRepositorie>();
builder.Services.AddScoped<IPacienteRepositorie, PacienteRepositorie>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
