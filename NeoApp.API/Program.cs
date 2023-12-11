using Microsoft.EntityFrameworkCore;
using NeoApp.API.Models;
using NeoApp.API.Repositories;
using NeoApp.API.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using NeoApp.API.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ControleConsultaContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:DataBase"))
);

builder.Services.AddScoped<IConsultaRepositorie, ConsultaRepositorie>();
builder.Services.AddScoped<IMedicoRepositorie, MedicoRepositorie>();
builder.Services.AddScoped<IPacienteRepositorie, PacienteRepositorie>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserRolePolicy", policy =>
    {
        policy.Requirements.Add(new UserRoleRequirement());
    });

    // Adicione políticas adicionais conforme necessário
    options.AddPolicy("PacientePolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Paciente");
    });

    options.AddPolicy("MedicoPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Medico");
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, UserRoleHandler>();

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

app.UseAuthentication();
app.UseAuthorization();

app.Run();
