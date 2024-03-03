namespace SaveTheOcean
{
    public class TortugaMarina : Animal
    {
        public TortugaMarina() : base(GenerarNombreAleatorio(), "Tortuga Marina", "Chelonia mydas", GenerarPesoAproximado())
        {

        }

        /// <summary>
        /// Método para aplicar el tratamiento del grado de afectación dependiendo de la localizacion
        /// </summary>
        /// <param name="localizacion">Parámetro de la localización actual del animal</param>
        /// <param name="gradoAfectacion">Parámetro del grado de afectación del animal</param>
        /// <returns></returns>
        public override int AplicarTratamiento(string localizacion, int gradoAfectacion)
        {
            int x = 5;
            int nuevoGradoAfectacion = gradoAfectacion - ((gradoAfectacion - 2) * (2 * gradoAfectacion + 3)) - x;
            return nuevoGradoAfectacion;
        }

        /// <summary>
        /// Método para generar nombre aleatorio entre 3 disponibles
        /// </summary>
        /// <returns>Devuelve un string</returns>
        private static string GenerarNombreAleatorio()
        {
            string[] nombres = ["Oumou", "Valpa", "Dory"];
            return nombres[new Random().Next(0, nombres.Length)];
        }

        /// <summary>
        /// Método para generar el peso aproximado del animal
        /// </summary>
        /// <returns>Devuelve un double</returns>
        private static double GenerarPesoAproximado()
        {
            Random random = new Random();
            double pesoAleatorio = random.NextDouble() * (200.0 - 100.0) + 100.0;
            return Math.Round(pesoAleatorio, 2);
        }
    }
}
