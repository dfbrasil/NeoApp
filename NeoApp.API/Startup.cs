/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeoApp.API.Models;
using NeoApp.API.Repositories;
using NeoApp.API.Repositories.Interfaces;
using System.Globalization;
using System.Collections.Generic;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<ControleConsultaContext>(
            options => options.UseSqlServer(Configuration.GetConnectionString("DataBase"))
        );

        services.AddScoped<IConsultaRepositorie, ConsultaRepositorie>();
        services.AddScoped<IMedicoRepositorie, MedicoRepositorie>();
        services.AddScoped<IPacienteRepositorie, PacienteRepositorie>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US") // Defina a cultura desejada aqui
        };

        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("en-US"),
            SupportedCultures = new List<CultureInfo>
        {
          new CultureInfo("en-US"),
          // Adicione outras culturas desejadas
        },
          SupportedUICultures = new List<CultureInfo>
        {
          new CultureInfo("en-US"),
          // Adicione outras culturas desejadas
        }
        });

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
*/