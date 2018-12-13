using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureThirdLinq
{
    class Program
    {
        static void Main()
        {
            string gamerNames = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            string[] splitedGamerNames = gamerNames.Split(' ');
            var numbersAndNames = numbers.Zip(splitedGamerNames, (first, second) => first + " " + second);
            foreach (var name in numbersAndNames)
            {
                System.Console.WriteLine($"{name}");
            }

            string gamerUnsortedNames = "Jason Puncheon, 26/06/1986;"+
            "Jos Hooiveld, 22/04/1983;"+
            "Kelvin Davis, 29/09/1976;"+ 
            "Luke Shaw, 12/07/1995;"+
            "Gaston Ramirez, 02/12/1990;"+
            "Adam Lallana, 10/05/1988";


            var persons = gamerUnsortedNames.Split(';').Select(p => new 
            {
                Name = p.Split(',')[0],
                DOB = DateTime.ParseExact(p.Split(',')[1].Trim(), "dd/mm/yyyy", CultureInfo.InvariantCulture)
            }).OrderBy(s => s.DOB).ToList();

            persons.ForEach(p => Console.WriteLine(p.DOB));

            var songsDurationsInMinutes = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var commonDurationInMinutes = songsDurationsInMinutes.Split(',').
                Sum(p => TimeSpan.Parse(p).Ticks);
            Console.WriteLine(commonDurationInMinutes);


            Console.ReadKey();
        }
    }
}
