using System;
using Xunit;
using NeoApp.API.Repositories;

namespace TestProject
{
    public class ConsultaDapperRepositoryTests
    {
        private readonly string _connectionString = "Data Source=(local);Initial Catalog=ControleConsulta;Integrated Security=True;Encrypt=False";

        [Fact]
        public void ObterConsultas_DeveRetornarConsultasCorretas()
        {
            // Arrange
            var consultaDapperRepository = new ConsultaDapperRepository(_connectionString);

            // Act
            var consultas = consultaDapperRepository.ObterConsultas();

            // Assert
            Xunit.Assert.NotNull(consultas);

            foreach (var consulta in consultas)
            {
                Console.WriteLine($"Consulta ID: {consulta.Id}");
                Console.WriteLine($"Data da Consulta: {consulta.DataConsulta}");
                Console.WriteLine();
            }
        }
    }
}
