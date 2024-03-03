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
        /// Método que sirve para añadir experiencia al jugador
        /// </summary>
        /// <param name="puntos">Puntos a añadir</param>
        public void GanarExperiencia(int puntos)
        {
            Experiencia += puntos;
        }

        /// <summary>
        /// Método que sirve para disminuir la experiencia del jugador
        /// </summary>
        /// <param name="puntos">Puntos a disminuir</param>
        public void PerderExperiencia(int puntos)
        {
            Experiencia -= puntos;
        }
    }
}
