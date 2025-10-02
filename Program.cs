namespace Bibloteket
{
    internal class Program
    {
        //Cajsa Mårtensson SUT25

        static string[] bookTitles = { "Mio, min Mio av Astrid Lindgren", "Pippi Långstrump av Astrid Lindgren", "Bröderna Lejonhjärta av Astrid Lindgren", "Lotta på bråkmakargatan av Astrid Lindgren", "Madicken av Astrid Lindgren" };

        static int[] numberOfCopies = { 3, 4, 2, 3, 2 };

        static void Main(string[] args)
        {
            LogIn();
            int selectedChoice = Choices();
            ChooseOption(selectedChoice);
        }

        static void LogIn()
        {
            bool loggedIn = false;

            string[] usernames = { "nallepuh", "nasse", "ior", "tiger", "uggla" };
            int[] password = { 1234, 4321, 6381, 9836, 5376 };

            Console.WriteLine("Välkommen till biblotekets lånesystem!");

            //Loop that gives user max 3 attempts to try to log in
            for (int attempts = 0; attempts < 3; attempts++)
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
            Console.WriteLine("1. Visa böcker");
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

        static void ChooseOption(int a)
        {
            switch (a)
            {
                case 1:
                    ShowBooks();
                    break;
                case 2:
                    BorrowBooks();
                    break;
                case 3:
                    //Lämna tillbaka lånad bok
                    break;
                case 4:
                    //Mina Lån
                    break;
                case 5:
                    //Logga ut
                    break;
            }
        }

        static int[] ShowBooks()
        {
            //int[] numberOfCopies = { 3, 4, 2, 3, 2 };

            //string[] bookTitles = { "Mio, min Mio av Astrid Lindgren", "Pippi Långstrump av Astrid Lindgren", "Bröderna Lejonhjärta av Astrid Lindgren", "Lotta på bråkmakargatan av Astrid Lindgren", "Madicken av Astrid Lindgren" };

            Console.WriteLine("Alla tillgängliga böcker:");
            Console.WriteLine($"1. {bookTitles[0]}. {numberOfCopies[0]} exemplar.");
            Console.WriteLine($"2. {bookTitles[1]}. {numberOfCopies[1]} exemplar.");
            Console.WriteLine($"3. {bookTitles[2]}. {numberOfCopies[2]} exemplar.");
            Console.WriteLine($"4. {bookTitles[3]}. {numberOfCopies[3]} exemplar.");
            Console.WriteLine($"5. {bookTitles[4]}. {numberOfCopies[4]} exemplar.");

            return numberOfCopies;

        }

        static void BorrowBooks()
        {
            Console.WriteLine("Välj vilken bok du vill låna genom att ange nummer.");
            int book;
            while (!int.TryParse(Console.ReadLine(), out book) || book < 1 || book > 5)
            {
                Console.WriteLine("Ogiltligt val.");
            }


        }
    }
}
