using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRARYLABGC
{
   public class Book
    {
        public string bookName { get; set; }
        public string Author { get; set; }
        public string isCheckedOut { get; set; }
        public string dueDate { get; set; }
        public string checkedOutBy { get; set; }

    }
    class Program
    {
        public static string userName;

        public static List<Book> bookDirectory = new List<Book>
        {
            new Book{bookName="Generic Book 1",Author="Generic Author 1",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 2",Author="Generic Author 2",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 3",Author="Generic Author 3",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 4",Author="Generic Author 4",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 5",Author="Generic Author 5",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 6",Author="Generic Author 6",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 7",Author="Generic Author 7",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 8",Author="Generic Author 8",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 9",Author="Generic Author 9",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 10",Author="Generic Author 10",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 11",Author="Generic Author 11",isCheckedOut="not checked out",dueDate="",checkedOutBy=""},
            new Book{bookName="Generic Book 12",Author="Generic Author 12",isCheckedOut="not checked out",dueDate="",checkedOutBy=""}
        };

        static void Main()
        {
            Console.Write("Log in name: ");
            userName = Console.ReadLine();
            Console.Write($"\nGreetings, {userName}.\n");
            mainMenu();
        }
        public static List<Book> Sorter(string choice) //sort the list based on author or title 
        {

            List<Book> sortedList = new List<Book>();

            while (true)
            {
                if (choice == "Author")
                {
                    sortedList = bookDirectory.OrderBy(b => b.Author).ToList();
                    return sortedList;
                }
                else if (choice == "Title")
                {
                    sortedList = bookDirectory.OrderBy(b => b.bookName).ToList();
                    return sortedList;
                }
                else
                {
                    Console.WriteLine("\nInvalid selection. Please try again.");
                    choice = Console.ReadLine();
                    continue;
                }
            }
        }
        public static void sortPrompter() //prompts user to sort if desired then calls Sorter()
        {
            Console.WriteLine("\nPlease enter either \"Author\" or \"Title\".");
            bookDirectory = Sorter(sortChoiceChecker(Console.ReadLine()));
            Console.WriteLine("\nWould you like to sort this list again? (y/n)");
            string choice = yesNoChecker(Console.ReadLine());
            if (choice == "y")
            {
                sortPrompter();
            }
            else
            {
                Console.WriteLine("\nReturning to main menu . . .\n");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                mainMenu();
            }
        }
        public static string yesNoChecker(string choice) //validates the many y/n decisions in this program
        {
            while (choice != "y" && choice != "n")
            {
                Console.WriteLine("\nInvalid choice. Please enter \"y\" for yes or \"n\" for no.");
                choice = Console.ReadLine();
            }
            return choice;
        }
        public static string sortChoiceChecker(string choice)
        {
            while (choice != "Author" && choice != "Title")
            {
                Console.WriteLine("\nInvalid choice. Please enter \"Author\" to sort by author or \"Title\" to sort by title.");
                choice = Console.ReadLine();
            }
            return choice;
        }//validates choices for sort
        public static void bookAdder()//adds new book and offers decision to add another
        {
            string author, title, choice;
            author = "";
            title = "";
            choice = "";
            Console.Write("\nPlease enter the name of the author:");
            author = Console.ReadLine();
            Console.Write("\nPlease enter the title of the book:");
            title = Console.ReadLine();
            bookDirectory.Add(new Book() { bookName = title, Author = author, isCheckedOut = "No", checkedOutBy = "",  dueDate = "" });
            Console.Write("\nBook added to Directory.\nWould you like to add another book? (y/n): ");
            choice = yesNoChecker(Console.ReadLine());
            if(choice == "y")
            {
                bookAdder();
            }
            else
            {
                Console.WriteLine("\nReturning to main menu . . .\n");
                System.Threading.Thread.Sleep(1500);
                mainMenu();
            }
        }
        public static void mainMenu()//adds options to access all other methods
        {
            Console.Write("\nWelcome to the Library Main Menu." +
                "\nPlease enter a number corresponding to the following options:" +
                "\n1): View list of all books in directory" +
                "\n2): Search for book in directory" +
                "\n3): Checkout a book" +
                "\n4): Return a book" +
                "\n5): Get checkout status of book" +
                "\n6): Add book to directory" +
                "\n7): Sort books by Author/Title" +
                "\n8): Exit terminal" +
                "\nEnter choice: ");
            string choice = mainMenuChecker(Console.ReadLine());
            switch(choice)
            {
                case "1":
                    bookDisplay();
                    break;
                case "2":
                    bookSearch();
                    break;
                case "3":
                    Checkout();
                    break;
                case "4":
                    returnBook();
                    break;
                case "5":
                    checkoutCheck();
                    break;
                case "6":
                    bookAdder();
                    break;
                case "7":
                    sortPrompter();
                    break;
                case "8":
                    Console.WriteLine("\nGoodbye");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        public static string mainMenuChecker(string choice)
        {
            while(choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7" && choice != "8")
            {
                Console.Write("\nInvalid choice. Please enter a number 1 - 8: ");
                choice = Console.ReadLine();
            }
            return choice;
        }//verifies choice made for main menu
        public static void bookDisplay()
        {
            int i = 0;
            foreach (var book in bookDirectory)
            {
                i++;
                Console.WriteLine($"{i}: \"" + book.bookName + "\", " + book.Author);
            }
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine("\nPress any key to return to the main menu . . .\n");
            Console.ReadKey();
            Console.WriteLine("\nReturning to main menu . . .\n");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            mainMenu();
        }//displays list of books when called
        public static void bookSearch()//display results of search
        {
            Console.Write("\nInput a word or words to search books for: ");
            string input = Console.ReadLine();
            int i = 0;
            foreach(var book in bookDirectory)
            {
                if(book.Author.Contains(input) || book.bookName.Contains(input))
                {
                    i++;
                    Console.WriteLine($"{i}: \"{book.bookName}\", {book.Author}");
                }
            }
            if (i == 0)
            {
                Console.WriteLine("\nNo matches found.");
            }
            else
            {
                Console.WriteLine($"\nFound {i} matches.");
            }
            Console.WriteLine("\nReturning to main menu . . .\n");
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            mainMenu();
        }
        public static void Checkout()//allows you to checkout book //gonna have to add validation for checkout
        {
            string choice;
            choice = "";
            string choice2;
            choice2 = "";
            Console.Write("\nInput title of book you wish to check out: ");
            string input = bookMatch(Console.ReadLine());
            foreach (var book in bookDirectory)
            {
                if (book.bookName == input)
                {
                    Console.Write($"\nYou have selected \"{book.bookName}\" by {book.Author}." +
                        $"\nIs that correct? (y/n): ");
                    choice = yesNoChecker(Console.ReadLine());
                }
            }
            if(choice == "y")
            {
                foreach (var book in bookDirectory)
                {
                    if (book.bookName == input && book.isCheckedOut == "not checked out")
                    {
                        Console.WriteLine($"\nChecking out book to {userName}. . .");
                        book.isCheckedOut = "checked out";
                        DateTime today = DateTime.Now;
                        TimeSpan timespan = new TimeSpan(14, 0, 0, 0);
                        DateTime duedate = today.Add(timespan);
                        book.dueDate = duedate.ToString("MM/dd/yyyy");
                        book.checkedOutBy = userName;
                    }
                    else if(book.bookName == input && book.isCheckedOut == "checked out")
                    {
                        Console.WriteLine("\nBook is already checked out.");
                    }
                }
                Console.Write("\nWould you like to check out another book? (y/n): ");
                choice2 = yesNoChecker(Console.ReadLine());
                if (choice2 == "y")
                {
                    Checkout();
                }
                else if (choice2 == "n")
                {
                    Console.WriteLine("\nReturning to main menu . . .\n");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    mainMenu();
                }
            }
            else if(choice == "n")
            {
                Console.Write("\nWould you like to check out another book? (y/n): ");
                choice2 = yesNoChecker(Console.ReadLine());
                if(choice2 == "y")
                {
                    Checkout();
                }
                else if(choice2 == "n")
                {
                    Console.WriteLine("\nReturning to main menu . . .\n");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    mainMenu();
                }
            }
        }
        public static string bookMatch(string input) //allows you to input new title/author if no match found
        {
            while(!bookCheck(input))
            {
                Console.Write("\nBook not found. Please enter another title: ");
                input = Console.ReadLine();
            }
            return input;
        }
        public static bool bookCheck(string input)//accesses objects and returns true if match found
        {
            foreach(var book in bookDirectory)
            {
                if(book.bookName == input)
                {
                    return true;
                }
            }
            return false;
        }
        public static void checkoutCheck()
        {
            Console.Write("\nPlease enter the title of a book to get its checkout status: ");
            string input = bookMatch(Console.ReadLine());
            string choice;
            choice = "";
            foreach (var book in bookDirectory)
            {
                if (book.bookName == input && book.isCheckedOut == "checked out")
                {
                    Console.Write($"\n\"{book.bookName}\" is currently {book.isCheckedOut} to {book.checkedOutBy} due by {book.dueDate}.");
                }
                if (book.bookName == input && book.isCheckedOut == "not checked out")
                {
                    Console.Write($"\n\"{book.bookName}\" is currently {book.isCheckedOut}.");
                }
            }
            Console.Write("\nWould you like to check the status of another book? (y/n): ");
            choice = "";
            choice = yesNoChecker(Console.ReadLine());
            if(choice == "y")
            {
                checkoutCheck();
            }
            else if (choice == "n")
            {
                Console.WriteLine("\nReturning to main menu . . .\n");
                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                mainMenu();
            }
        }// checks status of books
        public static void returnBook()//allows you to checkout book //gonna have to add validation for checkout
        {
            string choice;
            choice = "";
            string choice2;
            choice2 = "";
            Console.Write("\nInput title of book you wish to return: ");
            string input;
            input = bookMatch(Console.ReadLine());
            foreach (var book in bookDirectory)
            {
                if (book.bookName == input)
                {
                    Console.Write($"\nYou have selected \"{book.bookName}\" by {book.Author}." +
                        $"\nIs that correct? (y/n): ");
                    choice = yesNoChecker(Console.ReadLine());
                }
            }
            if (choice == "y")
            {
                foreach (var book in bookDirectory)
                {
                    if (book.bookName == input && book.isCheckedOut == "checked out")
                    {
                        Console.WriteLine($"\nReturning {book.bookName}. . .");
                        book.isCheckedOut = "not checked out";
                        book.dueDate = "";
                        book.checkedOutBy = "";
                    }
                    else if(book.bookName == input && book.isCheckedOut == "not checked out")
                    {
                        Console.WriteLine("\nBook is already checked in.");
                    }
                }
                Console.Write("\nWould you like to return another book? (y/n): ");
                choice2 = yesNoChecker(Console.ReadLine());
                if (choice2 == "y")
                {
                    Checkout();
                }
                else if (choice2 == "n")
                {
                    Console.WriteLine("\nReturning to main menu . . .\n");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    mainMenu();
                }
            }
            else if (choice == "n")
            {
                Console.Write("\n Would you like to check out another book? (y/n): ");
                choice2 = yesNoChecker(Console.ReadLine());
                if (choice2 == "y")
                {
                    Checkout();
                }
                else if (choice2 == "n")
                {
                    Console.WriteLine("\nReturning to main menu . . .\n");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    mainMenu();
                }
            }
        }
    }
}
