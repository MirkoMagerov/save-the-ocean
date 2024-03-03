namespace SaveTheOcean
{
    public class Program
    {
        public static void Main()
        {
            // *************************** DECLARACION CONSTANTES Y VARIABLES ***************************

            const string MSG_WELCOME = "¡Bienvenido a Save The Ocean, el juego de rescate de animales!";
            const string MSG_PLAY_OR_EXIT = "¿Que quieres hacer?\n1. Jugar\n2. Salir\nTu decisión: ";
            const string MSG_ROL = "1. Tècnic (45 XP)\n2. Veterinari (80 XP)\nTu decisión: ";
            const string MSG_ENTER_NAME = "Ingresa tu nombre porfavor: ";
            const string MSG_HELP_MSG = "Hola, {0}. El 112 ha recibido una llamada de aviso de un animal a rescatar. Los datos que tenemos son los siguientes: ";
            const string MSG_ANIMAL_INFO = "Aqui tienes la ficha del animal: ";
            const string MSG_GA_INFO = "El/la {0} tiene un grado de afectación del {1}%.\n¿Quieres curarla aquí (1) o trasladarla al centro (2)?\nTu decisión: ";
            const string MSG_NOT_HELPED_SUCCESSFULLY = "El tratamiento aplicado ha reducido el grado de afectación hasta el {0}%. No ha sido lo necesariamente efectivo y hay que tratar al animal al centro. Tu experiéncia se ha reducido en -20XP";
            const string MSG_HELPED_SUCCESSFULLY = "El tratamiento aplicado ha reducido el grado de afectación hasta el {0}%. El animal se esta recuperando y puede volver a su hñabitat. Tu experiéncia ha aumentado en +50XP.";
            const string MSG_FINAL_XP = "Tu experiéncia final es de {0}XP.\nHasta el próximo rescate.";
            const string MSG_BYE = "Gracias por jugar.";
            const int MIN_DECISION = 1, MAX_DECISION = 2, TECHNICIAN_XP = 45, VETERINARIAN_XP = 80, BAD_HELP = 20, GOOD_HELP = 50;

            string nombreJugador;
            int animalAleatorio = new Random().Next(0, 3), decisionMenu, decisionRol, decisionMedica;
            Jugador jugador;
            Rescate rescate;
            Animal animal = animalAleatorio switch
            {
                0 => new Cetaceo(),
                1 => new AuMarina(),
                _ => new TortugaMarina(),
            };

            // ******************************************************************************************

            Console.WriteLine(MSG_WELCOME);
            Console.WriteLine();

            // ESCOGER DECISION DE MENU
            do
            {
                Console.Write(MSG_PLAY_OR_EXIT);
                decisionMenu = Convert.ToInt16(Console.ReadLine());

            } while (!EleccionCorrecta(MIN_DECISION, MAX_DECISION, decisionMenu));

            Console.WriteLine();

            if (decisionMenu == 1)
            {
                // ESCOGER ROL
                do
                {
                    Console.Write(MSG_ROL);
                    decisionRol = Convert.ToInt16(Console.ReadLine());

                } while (!EleccionCorrecta(MIN_DECISION, MAX_DECISION, decisionRol));

                Console.WriteLine();

                // ESCOGER NOMBRE
                Console.Write(MSG_ENTER_NAME);
                nombreJugador = Console.ReadLine() ?? "Nombre por defecto";
                Console.WriteLine();

                // INSTANCIAR CLASES DEL JUGADOR Y CLASES RANDOM
                jugador = new Jugador(nombreJugador);
                jugador.Experiencia = decisionRol == 1 ? TECHNICIAN_XP : VETERINARIAN_XP;
                rescate = Rescate.GenerarRescateAleatorio(animal.Superfamilia);

                // MOSTRAR INFORMACION DEL RESCATE Y FITXA ANIMAL AL USUARIO
                Console.WriteLine(MSG_HELP_MSG, nombreJugador);
                Console.WriteLine();
                Console.WriteLine(rescate);

                Console.WriteLine();

                Console.WriteLine(MSG_ANIMAL_INFO);
                Console.WriteLine();
                Console.WriteLine(animal);

                Console.WriteLine();

                do
                {
                    Console.Write(MSG_GA_INFO, animal.Especie, rescate.GradoAfectacion);
                    decisionMedica = Convert.ToInt16(Console.ReadLine());

                } while (!EleccionCorrecta(MIN_DECISION, MAX_DECISION, decisionMedica));

                // CAMBIAR LOCALIZACION SOLO SI SE ELIGE TRASLADAR AL CRAM
                if (decisionMedica == 2)
                {
                    rescate.Localizacion = "En el CRAM";
                }

                rescate.GradoAfectacion = animal.AplicarTratamiento(rescate.Localizacion, rescate.GradoAfectacion);

                if (rescate.GradoAfectacion < 5)
                {
                    Console.WriteLine(MSG_HELPED_SUCCESSFULLY, rescate.GradoAfectacion);
                    jugador.GanarExperiencia(GOOD_HELP);
                }
                else
                {
                    Console.WriteLine(MSG_NOT_HELPED_SUCCESSFULLY, rescate.GradoAfectacion);
                    jugador.PerderExperiencia(BAD_HELP);
                }

                Console.WriteLine();
                Console.WriteLine(MSG_FINAL_XP, jugador.Experiencia);
            }

            else
            {
                Console.WriteLine(MSG_BYE);
            }
        }

        public static bool EleccionCorrecta(int valorMinimo, int valorMaximo, int eleccion)
        {
            return eleccion <= valorMaximo && eleccion >= valorMinimo;
        }
    }
}