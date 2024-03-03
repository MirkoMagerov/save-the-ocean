using SaveTheOcean;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumarPuntosJugador()
        {
            // Arrange
            Jugador jugador = new Jugador("Prueba");

            // Act
            int experienciaPrevia = jugador.Experiencia;
            jugador.GanarExperiencia(20);

            // Assert
            Assert.IsTrue(experienciaPrevia < jugador.Experiencia);
        }

        [TestMethod]
        public void RestarPuntosJugador()
        {
            // Arrange
            Jugador jugador = new Jugador("Prueba");

            // Act
            int experienciaPrevia = jugador.Experiencia;
            jugador.PerderExperiencia(20);

            // Assert
            Assert.IsTrue(experienciaPrevia > jugador.Experiencia);
        }

        [TestMethod]
        public void TestGradoAfectacionConCRAM_AuMarina()
        {
            // Arrange
            Animal auMarina = new AuMarina();
            string localizacion = "En el CRAM";
            int gradoAfectacion = 10;
            int expectedGradoAfectacion = 5;

            // Act
            int actualGradoAfectacion = auMarina.AplicarTratamiento(localizacion, gradoAfectacion);

            // Assert
            Assert.IsTrue(actualGradoAfectacion <= expectedGradoAfectacion);
        }

        [TestMethod]
        public void TestGradoAfectacionSinCRAM_AuMarina()
        {
            // Arrange
            Animal auMarina = new AuMarina();
            string localizacion = "Fuera del CRAM";
            int gradoAfectacion = 10;
            int expectedGradoAfectacion = gradoAfectacion - (gradoAfectacion * gradoAfectacion); // Calculamos el valor esperado

            // Act
            int actualGradoAfectacion = auMarina.AplicarTratamiento(localizacion, gradoAfectacion);

            // Assert
            Assert.AreEqual(expectedGradoAfectacion, actualGradoAfectacion);
        }

        [TestMethod]
        public void GenerarNombreAleatorio()
        {
            string[] nombres = ["Oumou", "Valpa", "Dory"];
            Animal auMarina = new AuMarina();

            Assert.IsTrue(nombres.Contains(auMarina.Nombre));
        }

        [TestMethod]
        public void GenerarPesoAproximado()
        {
            Random random = new Random();
            Animal auMarina = new AuMarina();
            Assert.IsTrue(auMarina.PesoAproximado >= 6 && auMarina.PesoAproximado <= 12);
        }

        [TestMethod]
        public void EleccionCorrecta_Correcta()
        {
            Assert.IsTrue(Program.EleccionCorrecta(1, 5, 3));
        }

        [TestMethod]
        public void EleccionCorrecta_Incorrecta()
        {
            Assert.IsFalse(Program.EleccionCorrecta(1, 5, 7));
        }
    }
}