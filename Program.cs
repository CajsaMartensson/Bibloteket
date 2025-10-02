namespace Bibloteket
{
    internal class Program
    {
        //Cajsa Mårtensson SUT25

        static void Main(string[] args)
        {
            LogIn();
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
    }
}
