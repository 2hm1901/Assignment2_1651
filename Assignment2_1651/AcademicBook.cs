using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class AcademicBook : Book
    {
        public string Category { get; set ; }
        public AcademicBook(string name, string author) : base(name, author) { Category = "Academic"; }
    }
}
