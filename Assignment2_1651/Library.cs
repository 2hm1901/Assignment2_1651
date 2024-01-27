using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment2_1651
{
    internal class Library
    {
        private static Library instance;
        private List<Book> listBook;
        private Library()
        {
            listBook = new List<Book>();
        }
        public static Library GetInstance()
        {
            if (instance == null)
            {
                lock (typeof(Library))
                {
                    if (instance == null)
                    {
                        instance = new Library();
                    }
                }
            }
            return instance;
        }
        public List<Book> ListBook { get { return listBook; } }
        public void AddBook(Book book)
        {
            listBook.Add(book);
        }
        public void AddBook()
        {
            string choiceType;
            do
            {
                Console.WriteLine("1. Academic book");
                Console.WriteLine("2. Funny book");
                Console.WriteLine("3. Cooking book");
                Console.Write("What kind of book you want to add: ");
                choiceType = Console.ReadLine();
                switch (choiceType)
                {
                    case "1":
                        Console.Write("Name's book: ");
                        string nameA = Console.ReadLine();
                        Console.Write("Author's book: ");
                        string authorA = Console.ReadLine();

                        listBook.Add(new AcademicBook(nameA, authorA));
                        Console.WriteLine("Done!");
                        break;
                    case "2":
                        Console.Write("Name's book: ");
                        string nameF = Console.ReadLine();
                        Console.Write("Author's book: ");
                        string authorF = Console.ReadLine();

                        listBook.Add(new FunnyBook(nameF, authorF));
                        Console.WriteLine("Done!");
                        break;
                    case "3":
                        Console.Write("Name's book: ");
                        string nameC = Console.ReadLine();
                        Console.Write("Author's book: ");
                        string authorC = Console.ReadLine();

                        listBook.Add(new CookingBook(nameC, authorC));
                        Console.WriteLine("Done!");
                        break;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
            } while (choiceType != "1" && choiceType != "2" && choiceType != "3");
        }
        public void DeleteBook()
        {
            DisplayAllBook();
            Console.Write("What book you want to delete: ");
            int deleteBook = int.Parse(Console.ReadLine());
            if(deleteBook > listBook.Count)
            {
                throw new NotExistBookException("Please choose the book on the list!");
            }
            else
            {
                listBook.RemoveAt(deleteBook - 1);
                Console.WriteLine("Done!");
            }
        }
        public Book FindBook(string name)
        {
            foreach (Book book in ListBook)
            {
                if (book.Name == name)
                {
                    return book;
                }
            }
            return null;
        }
        public void DisplayAllBook()
        {
            int i = 0;
            foreach(Book book in listBook)
            {
                Console.WriteLine($"{i+1}. {book.Name}, Author: {book.Author}, Available: {book.IsAvailable} {(!book.IsAvailable == true ? $", Current renter: {book.CurrentRenter}" : " ")}");
                i++;
            }
        }
        public string[] DisplayAvailableBook()
        {
            string[] tmpList = new string[ListBook.Count];
            int i = 0;
            Console.WriteLine("Available Book: ");
            foreach(Book book in listBook)
            {
                if (book.IsAvailable == true)
                {
                    if (book is AcademicBook)
                    {
                        AcademicBook ABook = (AcademicBook)book;
                        tmpList[i] = ABook.Name;
                        Console.WriteLine($"{i + 1}. Name: {ABook.Name}, Author: {ABook.Author}, Category:{ABook.Category}");
                        i++;
                    }
                    if (book is FunnyBook)
                    {
                        FunnyBook FBook = (FunnyBook)book;
                        tmpList[i] = FBook.Name;
                        Console.WriteLine($"{i + 1}. Name: {FBook.Name}, Author: {FBook.Author}, Category:{FBook.Category}");
                        i++;
                    }
                    if (book is CookingBook)
                    {
                        CookingBook CBook = (CookingBook)book;
                        tmpList[i] = CBook.Name;
                        Console.WriteLine($"{i + 1}. Name: {CBook.Name}, Author: {CBook.Author}, Category:{CBook.Category}");
                        i++;
                    }
                }
            }
            return tmpList;
        }
        public void BorrowBook(string id_user)
        {
            string id = id_user;
            string[] ListAvailableBook = DisplayAvailableBook();
            bool confirm = false;
            int choice;
            do
            {
                Console.Write("What book you want to borrow: ");
                choice = int.Parse(Console.ReadLine());
                if (choice >= ListAvailableBook.Length)
                {
                    throw new NotExistBookException("Please choose the book on the list!");
                }
                Console.Write($"Do you want to borrow {ListAvailableBook[choice - 1]} book?(y/n)");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    FindBook(ListAvailableBook[choice - 1]).SetAsBorrowed(id_user);
                    Console.WriteLine("Done!");
                    confirm = true;
                }
                else
                {
                    Console.WriteLine("Let choice again!");
                }
            } while (confirm == false);
        }
        public string[] DisplayBorrowedBook(string id_user) 
        {
            string[] tmpList = new string[ListBook.Count];
            int i = 0;
            Console.WriteLine("The book that you are borrowing: ");
            foreach(Book book in ListBook)
            {
                if(book.CurrentRenter == id_user)
                {
                    tmpList[i] = book.Name;
                    Console.WriteLine($"{i+1}. {book.Name}");
                    i++;
                }
            }
            return tmpList;
        }
        public void ReturnBook(string id_user)
        {
            string[] ListBorrowedBook = DisplayBorrowedBook(id_user);
            bool confirm = false;
            int choice;
            do
            {
                Console.Write("What book you want to return: ");
                choice = int.Parse(Console.ReadLine());
                if (choice >= ListBorrowedBook.Length)
                {
                    throw new NotExistBookException("Please choose the book on the list!");
                }
                else
                {
                    Console.Write($"Do you want to return {ListBorrowedBook[choice - 1]} book?(y/n)");
                    string answer = Console.ReadLine();
                    if (answer == "y" || answer == "Y")
                    {
                        FindBook(ListBorrowedBook[choice - 1]).SetAsReturned();
                        Console.WriteLine("Done!");
                        confirm = true;
                    }
                    else
                    {
                        Console.WriteLine("Let choice again!");
                    }
                }
            } while (confirm == false);
        }
        
    }
}
