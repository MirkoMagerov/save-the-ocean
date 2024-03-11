namespace SaveTheOcean
{
    public abstract class Animal : ITransportable
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
        /// Método que sobreescribe el ToString mostrando todos los atributos del animal
        /// </summary>
        /// <returns>Devuelve un string</returns>
        public override string ToString()
        {
            return $"Información del Animal:\n" +
                    $"------------------------\n" +
                    $"Nombre: {Nombre}\n" +
                    $"Superfamilia: {Superfamilia}\n" +
                    $"Especie: {Especie}\n" +
                    $"Peso Aproximado: {PesoAproximado} kg";
        }

        public abstract int AplicarTratamiento(string localizacion, int gradoAfectacion);
    }
}
