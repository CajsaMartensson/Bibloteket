namespace Bibloteket
{
    internal class Program
    {
        //Cajsa Mårtensson SUT25

        static void Main(string[] args)
        {
            LogIn();
            Choices();
        }

        static void LogIn()
        {
            bool loggedIn = false;

            string[] usernames = { "nallepuh", "nasse", "ior", "tiger", "uggla" };
            int[] password = { 1234, 4321, 6381, 9836, 5376 };

            Console.WriteLine("Välkommen till biblotekets lånesystem!");

           //Loop that gives user max 3 attempts to try to log in
            for (int attempts = 0; attempts <= 3; attempts++)
            {

                Console.Write("Skriv in ditt användarnamn: ");
                string writtenUsername = Console.ReadLine();

                Console.Write("Skriv in ditt lösenord: ");
                int writtenPassword;
                while (!int.TryParse(Console.ReadLine(), out writtenPassword))
                {
                    Console.WriteLine("Enbart siffror!");
                }

                //Control if written username och password match
                for (int i = 0; i < usernames.Length; i++)
                {
                    if (usernames[i] == writtenUsername && password[i] == writtenPassword)
                    {
                        loggedIn = true;
                        Console.WriteLine("Inloggning lyckades");
                        break;
                    }
                }
                if (loggedIn)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Fel användarnamn eller lösenord! Försök igen.");
                }
            }
        }

        static int Choices()
        {
            Console.WriteLine("Vad vill du göra? Ange vilken siffra");
            Console.WriteLine("1. Låna böcker");
            Console.WriteLine("2. Låna bok");
            Console.WriteLine("3. Lämna tillbaka bok");
            Console.WriteLine("4. Mina lån");
            Console.WriteLine("5. Logga ut");
        
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Ogiltligt val.");
            }

            return choice;
        }



    }
}
