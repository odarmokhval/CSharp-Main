using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureOneGenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList myOwnList = new LinkedList();
            myOwnList.PrintAllElements();
            Console.WriteLine();

            myOwnList.AddLastElement(12);
            myOwnList.AddLastElement("Student Andriy");
            myOwnList.AddLastElement("Student Mykola");
            myOwnList.AddLastElement(20);
            myOwnList.PrintAllElements();
            Console.WriteLine();

            myOwnList.AddFirstElement(25);
            myOwnList.PrintAllElements();
            Console.WriteLine();

            myOwnList.RemoveFirstElement();
            myOwnList.PrintAllElements();
            Console.WriteLine();

            Console.ReadKey();           
        }

        public class Element 
        {
            public Element Next;
            public object Value;
        }

        public class LinkedList
        {
            private Element head;
            private Element current;
            public int Count;

            public LinkedList()
            {
                head = new Element();
                current = head;
            }

            public void AddLastElement(object data)
            {
                Element newElement = new Element();
                newElement.Value = data;
                current.Next = newElement;
                current = newElement;
                Count++;
            }

            public void AddFirstElement(object data)
            {
                Element newElement = new Element() { Value = data};
                newElement.Next = head.Next;
                head.Next = newElement;
                Count++;
            }

            public void RemoveFirstElement()
            {
                if (Count > 0)
                {
                    head.Next = head.Next.Next;
                    Count--;
                }
                else
                {
                    Console.WriteLine("No element exist");
                }

            }

            public void PrintAllElements()
            {
                Console.Write("Head -> ");
                Element current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                    Console.Write($"{current.Value} -> ");                    
                }

                Console.Write("NULL");

            }

        }
    }
}

