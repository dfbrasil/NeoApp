using NeoApp.API.Models;

namespace TestProject
{
    [TestClass]
    public class MedicoTests
    {
        [TestMethod]
        public void NomeMedico_DeveTerMaisDeUmaLetra()
        {
            // Arrange
            var medico = new Medico { NomeMedico = "Dr. Silva" };

            // Act
            var resultado = medico.ValidarNome();

            // Assert
            Assert.IsTrue(resultado);
        }
    }
}