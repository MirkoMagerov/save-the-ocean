namespace SaveTheOcean
{
    public abstract class Animal
    {
        public string Nombre { get; set; }
        public string Superfamilia { get; set; }
        public string Especie { get; set; }
        public double PesoAproximado { get; set; }

        public Animal(string nombre, string superFamilia, string especie, double pesoAproximado)
        {
            Nombre = nombre;
            Superfamilia = superFamilia;
            Especie = especie;
            PesoAproximado = pesoAproximado;
        }

        /// <summary>
        /// M�todo abstracto para sobreescribir dependiendo del animal a tratar
        /// </summary>
        /// <param name="localizacion">Localizaci�n actual del animal</param>
        /// <param name="gradoAfectacion">Grado de afectaci�n del animal</param>
        /// <returns></returns>
        public abstract int AplicarTratamiento(string localizacion, int gradoAfectacion);

        /// <summary>
        /// M�todo que sobreescribe el ToString mostrando todos los atributos del animal
        /// </summary>
        /// <returns>Devuelve un string</returns>
        public override string ToString()
        {
            return $"Informaci�n del Animal:\n" +
                    $"------------------------\n" +
                    $"Nombre: {Nombre}\n" +
                    $"Superfamilia: {Superfamilia}\n" +
                    $"Especie: {Especie}\n" +
                    $"Peso Aproximado: {PesoAproximado} kg";
        }
    }
}
