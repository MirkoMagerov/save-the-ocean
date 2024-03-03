namespace SaveTheOcean
{
    public class AuMarina : Animal
    {
        public AuMarina() : base(GenerarNombreAleatorio(), "Au Marina", "Diomedea exulans", GenerarPesoAproximado())
        {

        }

        /// <summary>
        /// M�todo para aplicar el tratamiento del grado de afectaci�n dependiendo de la localizacion
        /// </summary>
        /// <param name="localizacion">Par�metro de la localizaci�n actual del animal</param>
        /// <param name="gradoAfectacion">Par�metro del grado de afectaci�n del animal</param>
        /// <returns></returns>
        public override int AplicarTratamiento(string localizacion, int gradoAfectacion)
        {
            bool curarEnLocalizacion = localizacion == "En el CRAM";
            int x = curarEnLocalizacion ? 5 : 0;
            int nuevoGradoAfectacion = gradoAfectacion - (gradoAfectacion * gradoAfectacion + x);
            return nuevoGradoAfectacion;
        }

        /// <summary>
        /// M�todo para generar nombre aleatorio entre 3 disponibles
        /// </summary>
        /// <returns>Devuelve un string</returns>
        private static string GenerarNombreAleatorio()
        {
            string[] nombres = ["Oumou", "Valpa", "Dory"];
            return nombres[new Random().Next(0, nombres.Length)];
        }

        /// <summary>
        /// M�todo para generar el peso aproximado del animal
        /// </summary>
        /// <returns>Devuelve un double</returns>
        private static double GenerarPesoAproximado()
        {
            Random random = new Random();
            double pesoAleatorio = random.NextDouble() * (12 - 6) + 6;
            return Math.Round(pesoAleatorio, 2);
        }
    }
}
