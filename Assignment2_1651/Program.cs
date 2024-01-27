using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System session = new System();
            History history = History.GetInstance();

            Account account = Account.GetInstance();
            account.Register(new Admin("AdminH", "S111"));
            account.Register(new Admin("AdminA", "S222"));
            account.Register(new Student("Hai", "S123"));

            Library library = Library.GetInstance();
            library.AddBook(new AcademicBook("Academic book 1", "Jack"));
            library.AddBook(new FunnyBook("Funny book 1", "Tom"));
            library.AddBook(new CookingBook("Cooking book 1", "Kale"));

            //Login
            bool CheckLogin = false;
            bool isStudent = false;
            bool isAdmin = false;
            string choice;
            do
            {
                Console.WriteLine("----------<WELCOME TO OUR SYSTEM>----------");
                Console.WriteLine("1. Login as Student");
                Console.WriteLine("2. Login as Admin");
                Console.WriteLine("3. Register");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Your id: ");
                        string idStudent = Console.ReadLine();
                        CheckLogin = session.StudentLogin(idStudent);
                        if(CheckLogin == true)
                        {
                            session.Name = account.FindUser(idStudent).Name;
                            session.Id = idStudent;
                            isStudent = true;
                            history.AddLog(new Log($"Student {session.Id} logged!"));
                        }
                        else
                        {
                            Console.WriteLine("Wrong!!!Try again!");
                        }
                        break;
                    case "2":
                        Console.Write("Your id: ");
                        string idAdmin = Console.ReadLine();
                        Console.Write("Admin's password: ");
                        string password = Console.ReadLine();
                        CheckLogin = session.AdminLogin(idAdmin, password);
                        if(CheckLogin == true)
                        {
                            session.Name = account.FindUser(idAdmin).Name;
                            session.Id = idAdmin;
                            isAdmin = true;
                            history.AddLog(new Log($"Admin {session.Id} logged!"));
                        }
                        else
                        {
                            Console.WriteLine("Wrong!!!Try again!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("---<Register>---");
                        try
                        {
                            Console.Write("Enter your name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter your id: ");
                            string id = Console.ReadLine();

                            account.Register(new Student(name, id));
                            history.AddLog(new Log($"New user {id} registed!"));
                        }
                        catch (InvalidNameException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (InvalidIdException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (DuplicateIdException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.StackTrace);
                        }
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!!!");
                        break;
                    default:
                        Console.WriteLine("Wrong choice! Choice again!");
                        break;
                }
                //Student functions
                if (CheckLogin)
                {
                    if (isStudent)
                    {
                        string cmdStudent;
                        do
                        {
                            Console.WriteLine($"----------<WELCOME STUDENT {session.Name}>----------");
                            Console.WriteLine("What you want to do:");
                            Console.WriteLine("1. Borrow Book");
                            Console.WriteLine("2. Return Book");
                            Console.WriteLine("3. Logout");
                            Console.Write("Your choice: ");
                            cmdStudent = Console.ReadLine();
                            switch(cmdStudent)
                            {
                                case "1":
                                    try
                                    {
                                        library.BorrowBook(session.Id);
                                        history.AddLog(new Log($"Student {session.Id} borrowed a book!"));
                                    }
                                    catch(FormatException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch(NotExistBookException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                case "2":
                                    try
                                    {
                                        library.ReturnBook(session.Id);
                                        history.AddLog(new Log($"Student {session.Id} returned a book!"));
                                    }
                                    catch(FormatException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }catch(NotExistBookException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine($"Goodbye {session.Name}!!!");
                                    CheckLogin = false;
                                    session.Name = null;
                                    session.Id = null;
                                    isStudent = false;
                                    history.AddLog(new Log($"Student {session.Id} logout!"));
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice!! Choice again!");
                                    break;
                            }
                        } while (cmdStudent != "3");
                    }
                    //Admin function
                    if (isAdmin)
                    {
                        string cmdAdmin;
                        do
                        {
                            Console.WriteLine($"-------<WELCOME ADMIN {session.Name}>--------");
                            Console.WriteLine("What do you want to do: ");
                            Console.WriteLine("1. Add book");
                            Console.WriteLine("2. Delete book");
                            Console.WriteLine("3. Check all status of book");
                            Console.WriteLine("4. History");
                            Console.WriteLine("5. Logout");
                            Console.Write("Your choice: ");
                            cmdAdmin = Console.ReadLine();
                            switch (cmdAdmin)
                            {
                                case "1":
                                    try
                                    {
                                        library.AddBook();
                                        history.AddLog(new Log($"Admin {session.Id} add a new book!"));
                                    }
                                    catch (DuplicateBookException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                case "2":
                                    try
                                    {
                                        library.DeleteBook();
                                        history.AddLog(new Log($"Admin {session.Id} delete a book"));
                                    }
                                    catch(FormatException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }catch(NotExistBookException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    break;
                                case "3":
                                    library.DisplayAllBook();
                                    break;
                                case "4":
                                    history.DisplayLog();
                                    break;
                                case "5":
                                    Console.WriteLine("Good bye Admin!");
                                    CheckLogin = false;
                                    session.Name = null;
                                    session.Id = null;
                                    isAdmin = false;
                                    history.AddLog(new Log($"Admin {session.Id} loggout!"));
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice!");
                                    break;
                            }
                        } while (cmdAdmin != "5");
                    }
                }
                    
            } while (CheckLogin == false && choice != "4");

            
            Console.ReadLine();
        }
    }
}
