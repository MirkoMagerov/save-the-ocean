namespace SaveTheOcean
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public int Experiencia { get; set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Experiencia = 0;
        }

        /// <summary>
        /// M�todo que sirve para a�adir experiencia al jugador
        /// </summary>
        /// <param name="puntos">Puntos a a�adir</param>
        public void GanarExperiencia(int puntos)
        {
            Experiencia += puntos;
        }

        /// <summary>
        /// M�todo que sirve para disminuir la experiencia del jugador
        /// </summary>
        /// <param name="puntos">Puntos a disminuir</param>
        public void PerderExperiencia(int puntos)
        {
            Experiencia -= puntos;
        }
    }
}
