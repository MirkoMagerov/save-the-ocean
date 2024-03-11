namespace SaveTheOcean
{
    public interface ITransportable
    {

        /// <summary>
        /// M�todo abstracto para sobreescribir dependiendo del animal a tratar
        /// </summary>
        /// <param name="localizacion">Localizaci�n actual del animal</param>
        /// <param name="gradoAfectacion">Grado de afectaci�n del animal</param>
        /// <returns></returns>
        public abstract int AplicarTratamiento(string localizacion, int gradoAfectacion);
    }
}
