namespace SaveTheOcean
{
    public interface ITransportable
    {

        /// <summary>
        /// Método abstracto para sobreescribir dependiendo del animal a tratar
        /// </summary>
        /// <param name="localizacion">Localización actual del animal</param>
        /// <param name="gradoAfectacion">Grado de afectación del animal</param>
        /// <returns></returns>
        public abstract int AplicarTratamiento(string localizacion, int gradoAfectacion);
    }
}
