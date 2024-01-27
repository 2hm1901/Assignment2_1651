using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class CookingBook : Book
    {
        public string Category { get; set; }
        public CookingBook(string name, string author) : base(name, author) { Category = "Cooking"; }
    }
}
