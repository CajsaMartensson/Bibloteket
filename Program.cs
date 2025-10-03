namespace Bibloteket
{
    internal class Program
    {
        //Cajsa Mårtensson SUT25

        static string[] bookTitles = { "Mio, min Mio av Astrid Lindgren", "Pippi Långstrump av Astrid Lindgren", "Bröderna Lejonhjärta av Astrid Lindgren", "Lotta på bråkmakargatan av Astrid Lindgren", "Madicken av Astrid Lindgren" };
        static int[] numberOfCopies = { 3, 4, 2, 3, 2 };

        static int[] savedBooks = new int[4];
        //För att ha ett startvärde på antal lånade böcker:
        static int savedBooksAmount = 0;

        static void Main(string[] args)
        {
            LogIn();

            bool isRunning = true;

            while (isRunning)
            {
                int selectedChoice = Choices();
                ChooseOption(selectedChoice);

            }

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

        static bool ChooseOption(int a)
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
                    ReturnBook();
                    break;
                case 4:
                    //Mina Lån
                    break;
                case 5:
                    LogIn();
                    return false;
                    break;
            }
            return true;
        }

        static void ShowBooks()
        {
            Console.WriteLine("Alla tillgängliga böcker:");
            Console.WriteLine($"1. {bookTitles[0]}. {numberOfCopies[0]} exemplar.");
            Console.WriteLine($"2. {bookTitles[1]}. {numberOfCopies[1]} exemplar.");
            Console.WriteLine($"3. {bookTitles[2]}. {numberOfCopies[2]} exemplar.");
            Console.WriteLine($"4. {bookTitles[3]}. {numberOfCopies[3]} exemplar.");
            Console.WriteLine($"5. {bookTitles[4]}. {numberOfCopies[4]} exemplar.");
        }

        static int BorrowBooks()
        {
            Console.Write("Välj vilken bok du vill låna genom att ange nummer: ");
            int book;
            while (!int.TryParse(Console.ReadLine(), out book) || book < 1 || book > 5)
            {
                Console.WriteLine("Ogiltligt val.");
            }

            //Eftersom den börjar räkna på 0, så användarens 3 är egentligen 2, därav -1
            int chosenBook = book - 1;

            if (numberOfCopies[chosenBook] > 0)
            {
                Console.WriteLine("Denna bok kan du låna.");
                numberOfCopies[chosenBook]--;
                SaveBooksInArray(chosenBook);
            }
            else
            {
                Console.WriteLine("Tyvärr, inga exemplar av denna bok.");
            }

            return chosenBook;
        }

        static void SaveBooksInArray(int a)
        {

            //Om man har lånat mer än savedBooks (global array) längd. Plussa på för varje gång, tills att man inte kan låna fler.
            if (savedBooksAmount < savedBooks.Length)
            {
                savedBooks[savedBooksAmount] = a;
                savedBooksAmount++;
            }
            else
            {
                Console.WriteLine("Du kan inte låna fler böcker.");
            }

            Console.WriteLine($"Du har lånat {bookTitles[a]} ");
        }

        static void ReturnBook()
        {
            if(savedBooksAmount == 0)
            {
                Console.WriteLine("Du har inga lånade böcker");
            }

            for (int i = 0; i < savedBooksAmount; i++)
            {
                int numberInArray = savedBooks[i];
                Console.WriteLine($"Du har lånat: {bookTitles[numberInArray]}");
            }

        }
    }
}