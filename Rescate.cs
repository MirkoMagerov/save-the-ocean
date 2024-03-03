namespace SaveTheOcean
{
    public class Rescate
    {
        public string NumeroRescate { get; set; }
        public string FechaRescate { get; set; }
        public string Superfamilia { get; set; }
        public int GradoAfectacion { get; set; }
        public string Localizacion { get; set; }

        public Rescate(string superfamilia, int gradoAfectacion, string localizacion)
        {
            NumeroRescate = "RES" + new Random().Next(0, 1001);
            FechaRescate = DateTime.Now.ToString("dd/MM/yyyy");
            Superfamilia = superfamilia;
            GradoAfectacion = gradoAfectacion;
            Localizacion = localizacion;
        }
        /// <summary>
        /// M�todo est�tico que genera un rescate con valores aleatorios excepto por el nombre de superfamilia
        /// </summary>
        /// <param name="superFamilia">Como la superfamilia debe de ser la misma en el rescate como en la ficha del animal, se pasa como par�metro una vez creada la ficha del animal</param>
        /// <returns></returns>
        public static Rescate GenerarRescateAleatorio(string superFamilia)
        {
            int gradoAfectacion = new Random().Next(1, 100);
            string[] localizaciones = ["En la ubicaci�n", "En el CRAM"];
            string localizacion = localizaciones[new Random().Next(0, 2)];

            return new Rescate(superFamilia, gradoAfectacion, localizacion);
        }

        /// <summary>
        /// M�todo que devuelve los atributos del rescate en formato parecido a una tabla.
        /// </summary>
        /// <returns>Devuelve un cadena de texto con los valores de cada atributo</returns>
        public override string ToString()
        {
            return $"Informaci�n del Rescate:\n" +
                    $"------------------------\n" +
                    $"N�mero de Rescate: {NumeroRescate}\n" +
                    $"Fecha del Rescate: {FechaRescate}\n" +
                    $"Superfamilia: {Superfamilia}\n" +
                    $"Grado de Afectaci�n: {GradoAfectacion}%\n" +
                    $"Localizaci�n: {Localizacion}";
        }
    }
}
