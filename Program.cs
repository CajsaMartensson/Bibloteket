namespace Bibloteket
{
    internal class Program
    {
        //Cajsa Mårtensson SUT25

        //Använd en jagged array för samla alla användare och lösenord i samma array och spara böckerna i dessa. 
        static string[][] userData = new string[3][];

        static string[] bookTitles = new string[] { "Mio, min Mio av Astrid Lindgren", "Pippi Långstrump av Astrid Lindgren", "Bröderna Lejonhjärta av Astrid Lindgren", "Lotta på bråkmakargatan av Astrid Lindgren", "Madicken av Astrid Lindgren" };
        static string[] numberOfCopies = new string[] { "3", "4", "2", "3", "2" };
        static string[] savedBooks = new string[4];

        //För att ha ett startvärde på antal lånade böcker:
        static int savedBooksAmount = 0;

        static void Main(string[] args)
        {
            LogIn();
            Console.Clear();

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
                        Console.WriteLine("Inloggning lyckades!");
                        break;
                    }
                }

                if (loggedIn)
                {
                    Console.WriteLine();
                    Console.WriteLine("Tryck enter för att fortsätta!");
                    Console.ReadKey();
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
                    Console.Clear();
                    ShowBooks();
                    break;
                case 2:
                    Console.Clear();
                    BorrowBooks();
                    break;
                case 3:
                    Console.Clear();
                    ReturnBook();
                    break;
                case 4:
                    Console.Clear();
                    MyLoans();
                    break;
                case 5:
                    Console.Clear();
                    LogIn();
                    return false;
                    break;
            }
            return true;
        }

        static void ShowBooks()
        {
            Console.WriteLine("Alla tillgängliga böcker:");
            for (int i = 0; i < bookTitles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {bookTitles[i]}. {numberOfCopies[i]} exemplar.");
            }

            Console.WriteLine();
            Console.WriteLine("Tryck enter för att fortsätta!");
            Console.ReadKey();
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

            //Konventera string (numberOfCopies) to int
            int copiesOfChosenBook = int.Parse(numberOfCopies[chosenBook]);

            if (copiesOfChosenBook > 0)
            {
                Console.WriteLine("Denna bok finns att låna.");
                copiesOfChosenBook--;
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
                savedBooks[savedBooksAmount] = bookTitles[a];
                savedBooksAmount++;


                //Konventera string numberOfCopies till int. Ta bort en bok från exemplar.
                int amountOfCopies = int.Parse(numberOfCopies[a]);
                amountOfCopies--;
                numberOfCopies[a] = amountOfCopies.ToString();
            }
            else
            {
                Console.WriteLine("Du kan inte låna fler böcker.");
            }

            Console.WriteLine($"Du har lånat {bookTitles[a]} ");
        }

        static void ReturnBook()
        {
            MyLoans();


            Console.WriteLine("Skriv siffran på den bok vill du lämna tillbaka?");
            int book;
            while (!int.TryParse(Console.ReadLine(), out book) || book < savedBooksAmount || book > savedBooksAmount)
            {
                Console.WriteLine("Ogiltligt val.");
            }


            //Eftersom den börjar räkna på 0
            int chosenBook = book - 1;

            string returnedBook = savedBooks[chosenBook];

            for (int i = 0; i < bookTitles.Length; i++)
            {
                if (bookTitles[i] == returnedBook)
                {
                    int copies = int.Parse(numberOfCopies[i]);
                    copies++;
                    numberOfCopies[i] = copies.ToString();
                    Console.WriteLine($"Du har lämnat {bookTitles[i]} tillbaka");
                }
            }
        }

        static void MyLoans()
        {
            if (savedBooksAmount == 0)
            {
                Console.WriteLine("Du har inga lånade böcker");
            }

            else
            {
                Console.WriteLine("Dina lånade böcker:");
                for (int i = 0; i < savedBooksAmount; i++)
                {
                    Console.WriteLine($"{i + 1}. {savedBooks[i]}");
                }
            }
        }
    }
}
