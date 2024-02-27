namespace SaveTheOcean
{
    class Program
    {
        public static void Main()
        {
            const string MSG_WELCOME_MESSAGE = "Bienvenido a Save the Ocean!. Elige una de las siguientes opciones: ";
            const string MSG_OPTIONS = "1. Jugar\n2. Salir\n\nTu eleccion: ";

            int userOption;

            Console.WriteLine(MSG_WELCOME_MESSAGE);

            do
            {

                Console.Write(MSG_OPTIONS);
                userOption = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

            } while (userOption != 1 && userOption != 2);
        }
    }
}