using System;

namespace Bibloteket
{
    internal class Program
    {
        //Cajsa Mårtensson SUT25

        //BÖCKER
        static string[] bookTitles = { "Mio min Mio av Astrid Lindgren", "Pippi Långstrump av Astrid Lindgren", "Bröderna Lejonhjärta av Astrid Lindgren", "Lotta på bråkmakargatan av Astrid Lindgren", "Madicken av Astrid Lindgren" };
        static string[] numberOfCopies = { "3", "4", "2", "3", "2" };

        //Använd en jagged array för samla alla användare och lösenord i samma array och spara böckerna i dessa. 
        static string[] user1 = ["nallepuh", "1234", ""];
        static string[] user2 = ["nasse", "4321", ""];
        static string[] user3 = ["ior", "6381", ""];
        static string[] user4 = ["tiger", "9836", ""];
        static string[] user5 = ["uggla", "5376", ""];
        static string[][] userData = [user1, user2, user3, user4, user5];

        static int loggedInUser;

        //För att ha ett startvärde på antal lånade böcker:
        static int savedBooksAmount = 0;

        static void Main(string[] args)
        {
            RunProgram();
        }

        static void RunProgram()
        {
            Console.Clear();

            bool isRunning = LogIn();

            if (isRunning)
                while (isRunning)
                {
                    Console.WriteLine();
                    int selectedChoice = Choices();
                    ChooseOption(selectedChoice);
                }
            else
            {
                Console.WriteLine("Programmet avslutas.");
            }
        }

        static bool LogIn()
        {
            Console.WriteLine("Välkommen till biblotekets lånesystem! Du har 3 försök att logga in!");

            //Loop that gives user max 3 attempts to try to log in
            for (int attempts = 0; attempts < 3; attempts++)
            {
                Console.Write("\nSkriv in ditt användarnamn: ");
                string writtenUsername = Console.ReadLine();

                Console.Write("Skriv in din PIN-kod: ");
                string writtenPassword = Console.ReadLine();

                //Control if written username och password match
                for (int i = 0; i < userData.Length; i++)
                {
                    if (userData[i][0] == writtenUsername && userData[i][1] == writtenPassword)
                    {
                        loggedInUser = i;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Inloggning lyckades!");
                        Console.ForegroundColor = ConsoleColor.White;
                        PressEnterToContinue();
                        return true;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fel användarnamn eller lösenord! Försök igen.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Du har gjort 3 misslyckade försök.");
            return false;
        }

        static int Choices()
        {
            Console.Clear();
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

            PressEnterToContinue();
        }

        static int BorrowBooks()
        {
            Console.WriteLine("Alla tillgängliga böcker:");
            for (int i = 0; i < bookTitles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {bookTitles[i]}. {numberOfCopies[i]} exemplar.");
            }

            Console.Write("\nVälj vilken bok du vill låna genom att ange nummer: ");
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
                Console.WriteLine($"Boken {bookTitles[chosenBook]} finns och är nu lånad.");
                savedBooksAmount++;
                copiesOfChosenBook--;
                SaveBooksInArray(chosenBook);
                PressEnterToContinue();
            }
            else
            {
                Console.WriteLine("Tyvärr, inga exemplar av denna bok.");
                PressEnterToContinue();
            }

            return chosenBook;
        }

        static void SaveBooksInArray(int a)
        {
            //Vald bok av användaren från metoden ovan
            string book = bookTitles[a];

            //Ser om användaren har några tidigare lån [först vilken användare] och sen [2: tom array]
            string currentLoans = userData[loggedInUser][2];

            //Inbyggd metod för om string är tom
            if (string.IsNullOrEmpty(currentLoans))
            {
                //Lägg till vald bok i den tomma arrayn
                userData[loggedInUser][2] = book;
            }
            else
            {
                //Hitta arrayen, om det finns en bok, addera den nya boken till stängen.
                userData[loggedInUser][2] += $", {book}";
            }

            //Konventera string numberOfCopies till int. Ta bort en bok från exemplar.
            int amountOfCopies = int.Parse(numberOfCopies[a]);
            amountOfCopies--;
            numberOfCopies[a] = amountOfCopies.ToString();
        }

        static void ReturnBook()
        {
            Loans();

            string returnedBook = userData[loggedInUser][2];
            string[] borrowedBooks = returnedBook.Split(", ");


            Console.WriteLine("Skriv siffran på den bok vill du lämna tillbaka?");
            int book;
            while (!int.TryParse(Console.ReadLine(), out book) || book < 1 || book > savedBooksAmount)
            {
                Console.WriteLine("Ogiltligt val. Försök igen.");
            }

            //Eftersom den börjar räkna på 0
            string chosenBook = borrowedBooks[book - 1];

            //Användaren lämnar tillbaka bok och boken plussas på i exemplar i bibloteket
            for (int i = 0; i < bookTitles.Length; i++)
            {
                if (bookTitles[i] == chosenBook)
                {
                    int copies = int.Parse(numberOfCopies[i]);
                    copies++;
                    numberOfCopies[i] = copies.ToString();
                    Console.WriteLine($"Du har lämnat tillbaka {bookTitles[i]}");
                    PressEnterToContinue();
                    break;
                }
            }

            //Skapa en ny array med de böcker som är kvar, de som user lämnat tillbaka blir inte med
            //borrowedBooks.Length - 1, är för jag vet att en ska bort så nya arrayen ska va 1 kortare.
            string[] newArrayWithoutOldBook = new string[borrowedBooks.Length - 1];

            //FÖr att ange hur många platser i arrayen, utan den hade det blivit tomrad om vid den bok vi hoppade över.
            int indexForNewArray = 0;

            //Loopa igenom varje bok jag lånat
            for (int i = 0; i < borrowedBooks.Length; i++)
                //Om boken inte är den som user lämnade tillbaka
                if (borrowedBooks[i] != chosenBook)
                {
                    //Lägg till boken i den nya arrayn
                    newArrayWithoutOldBook[indexForNewArray] = borrowedBooks[i];
                    indexForNewArray++;
                }
            //Updatera användarens lån, globala array-lån
            userData[loggedInUser][2] = string.Join(", ", newArrayWithoutOldBook);
            savedBooksAmount--;
        }

        static void Loans()
        {
            string currentLoans = userData[loggedInUser][2];

            if (string.IsNullOrEmpty(currentLoans))
            {
                Console.WriteLine("Du har inga lånade böcker");
                return;
            }

            //Gjort om current loans till borrow books array
            string[] borrowedBooks = currentLoans.Split(", ");

            Console.WriteLine("Dina lånade böcker:");
            for (int i = 0; i < borrowedBooks.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {borrowedBooks[i]}");
            }
        }

        static void MyLoans()
        {
            Loans();
            PressEnterToContinue();
        }

        static void PressEnterToContinue()
        {
            Console.WriteLine("\nTryck Enter för att återgå till huvudmenyn");
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du måste trycka enter-knappen för att fortsätta");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}

