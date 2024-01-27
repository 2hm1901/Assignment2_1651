using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class Log
    {
        public string Message { get; set; }
        public string CurrentTime { get; set; }
        public Log(string message)
        {
            Message = message;
            CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
    }
}
