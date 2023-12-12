using NeoApp.API.Models;

namespace TestProject
{
    [TestClass]
    public class PacienteTests
    {
        [TestMethod]
        public void NomePaciente_DeveTerMaisDeUmaLetra()
        {
            // Arrange
            var paciente = new Paciente { NomePaciente = "João" };

            // Act
            var resultado = paciente.ValidarNome();

            // Assert
            Assert.IsTrue(resultado);
        }
    }
}