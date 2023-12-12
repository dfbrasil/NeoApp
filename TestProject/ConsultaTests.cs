using NeoApp.API.Models;

namespace TestProject
{
    [TestClass]
    public class ConsultaTests
    {
        [TestMethod]
        public void CalcularDiaJuliano_DeveRetornarDiaJulianoCorreto()
        {
            // Arrange
            var consulta = new Consulta { DataConsulta = new DateTime(2023, 1, 15) };

            // Act
            var diaJuliano = consulta.CalcularDiaJuliano();

            // Assert
            Assert.AreEqual(15, diaJuliano);
        }
    }
}