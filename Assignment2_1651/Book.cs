using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class Book
    {
        private string _name;
        public string Name
        {
            get
            {
                    return _name;    
            }
            set
            {
                Library library = Library.GetInstance();
                if (library.ListBook != null)
                {
                    foreach (Book book in library.ListBook)
                    {
                        if (book.Name == value)
                        {
                            throw new DuplicateBookException("This book is already in library!");
                        }
                    }
                }
                _name = value;
            }
        }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
        public string CurrentRenter { get; set; }

        public Book(string name, string author)
        {
            Name = name;
            Author = author;
            IsAvailable = true;
        }
        public void SetAsBorrowed(string id)
        {
            this.IsAvailable = false;
            this.CurrentRenter = id;
        }
        public void SetAsReturned()
        {
            this.IsAvailable = true;
            this.CurrentRenter = null;
        }
    }
}
