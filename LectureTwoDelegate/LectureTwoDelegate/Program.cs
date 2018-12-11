using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTwoDelegate
{
    class Program
    {

        public delegate void Message(string str);

        private class AlphaNumbericCollector
        {
            List<string> stringWithNumbers = new List<string>();

            public void Process(string s)
            {
                stringWithNumbers.Add(s);
                Console.WriteLine("added to numbers collection");                    
                
            }            
        }
        
        private class StringCollector
        {
            List<string> stringWithoutNumbers = new List<string>();
            public void Process(string s)
            {
                stringWithoutNumbers.Add(s);
                Console.WriteLine("added to string collection");
            }

        }
        
        static void Main(string[] args)
        {
            StringCollector sCollector = new StringCollector();
            AlphaNumbericCollector anCollector = new AlphaNumbericCollector();

            Console.WriteLine("Please enter a string: ");
            Message mes1 = sCollector.Process;
            Message mes2 = anCollector.Process;
            var s = Console.ReadLine();

            if (!s.Any(c => char.IsDigit(c)))
            {
                mes1(s);
            }
            else
            {
                mes2(s);
            }
            Console.ReadKey();
        }
    }
}

