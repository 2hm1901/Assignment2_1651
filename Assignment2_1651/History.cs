using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_1651
{
    internal class History
    {
        private static History instance;
        private List<Log> history = new List<Log>();
        public static History GetInstance()
        {
            if (instance == null)
            {
                lock (typeof(History))
                {
                    if (instance == null)
                    {
                        instance = new History();
                    }
                }
            }
            return instance;
        }
        public void AddLog(Log log)
        {
            history.Add(log);
        }
        public void DisplayLog()
        {
            foreach (Log log in history)
            {
                Console.WriteLine($"{log.CurrentTime}: {log.Message}");
            }
        }
    }
}
