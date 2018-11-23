using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTwoEvent
{
    public class Program
    {
        public delegate void StringProcessing(string source, string str);

        public class AlphaNumericCollector
        {
            List<string> list = new List<string>();
            public event StringProcessing OnStringProcessed;

            public void Process(string str)
            {
                list.Add(str);

                if (OnStringProcessed != null)
                {
                    OnStringProcessed("AlphaNumericCollector", str);
                }
            }
        }

        public class StringCollector
        {
            List<string> list = new List<string>();
            public event StringProcessing OnStringProcessed;

            public void Process(string str)
            {
                list.Add(str);

                if (OnStringProcessed != null)
                {
                    OnStringProcessed("StringCollector", str);
                }
            }
        }

        public static void Main()
        {
            StringCollector sCollector = new StringCollector();
            AlphaNumericCollector anCollector = new AlphaNumericCollector();

            sCollector.OnStringProcessed += OnStringProcess;
            anCollector.OnStringProcessed += OnStringProcess;

            while (true)
            {
                var s = Console.ReadLine();

                if (!s.Any(c => char.IsDigit(c)))
                {
                    sCollector.Process(s);
                }
                else
                {
                    anCollector.Process(s);
                }
            }
        }

        public static void OnStringProcess(string source, string str)
        {
            Console.WriteLine("String {0} processed by {1}", str, source);
        }
    }
}
