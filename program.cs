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
            const string MSG_NOT_HELPED_SUCCESSFULLY = "El tratamiento aplicado ha reducido el grado de afectación hasta el {0}%. No ha sido lo necesariamente efectivo y hay que tratar el animal en el centro. Tu experiencia se ha reducido en 20XP.";
            const string MSG_HELPED_SUCCESSFULLY = "El tratamiento aplicado ha reducido el grado de afectación hasta el {0}%. El animal se esta recuperando y puede volver a su hábitat. Tu experiencia ha aumentado en 50XP.";
            const string MSG_FINAL_XP = "Tu experiéncia final es de {0}XP.\nHasta el próximo rescate.";
            const string MSG_BYE = "Gracias por jugar.";
            const string DEFAULT_NAME = "Jugador";
            const string CRAM = "En el CRAM";
            const int MIN_DECISION = 1, MAX_DECISION = 2, MAX_HELPED_GA = 5, TECHNICIAN_XP = 45, VETERINARIAN_XP = 80, BAD_HELP = 20, GOOD_HELP = 50;

            string nombreJugador;
            int animalAleatorio = new Random().Next(0, 3), decisionMenu, decisionRol, decisionMedica;
            Jugador jugador;
            Rescate rescate;
            Animal animal = animalAleatorio switch
            {
                0 => new Cetaceo(),
                1 => new AveMarina(),
                _ => new TortugaMarina(),
            };

            // ******************************************************************************************

            Console.WriteLine(MSG_WELCOME);

            // ESCOGER DECISION DE MENU
            do
            {
                Console.WriteLine();
                Console.Write(MSG_PLAY_OR_EXIT);
                decisionMenu = Convert.ToInt16(Console.ReadLine());

            } while (!Helper.EleccionCorrecta(MIN_DECISION, MAX_DECISION, decisionMenu));

            if (decisionMenu == MIN_DECISION)
            {
                // ESCOGER ROL
                do
                {
                    Console.WriteLine();
                    Console.Write(MSG_ROL);
                    decisionRol = Convert.ToInt16(Console.ReadLine());

                } while (!Helper.EleccionCorrecta(MIN_DECISION, MAX_DECISION, decisionRol));

                // ESCOGER NOMBRE
                Console.WriteLine();
                Console.Write(MSG_ENTER_NAME);
                nombreJugador = Console.ReadLine() ?? "";
                if (nombreJugador == "") nombreJugador = DEFAULT_NAME;
                Console.WriteLine();

                // INSTANCIAR CLASES DEL JUGADOR Y CLASES RANDOM
                jugador = new Jugador(nombreJugador);
                jugador.Experiencia = decisionRol == MIN_DECISION ? TECHNICIAN_XP : VETERINARIAN_XP;
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

                } while (!Helper.EleccionCorrecta(MIN_DECISION, MAX_DECISION, decisionMedica));

                // CAMBIAR LOCALIZACION SOLO SI SE ELIGE TRASLADAR AL CRAM
                if (decisionMedica == MAX_DECISION)
                {
                    rescate.Localizacion = CRAM;
                }

                rescate.GradoAfectacion = animal.AplicarTratamiento(rescate.Localizacion, rescate.GradoAfectacion);

                if (rescate.GradoAfectacion < MAX_HELPED_GA)
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
    }
}