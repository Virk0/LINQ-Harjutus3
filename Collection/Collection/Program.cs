using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = System.IO.File.ReadAllLines("../../names.txt");
            var humans1 = new List<Human>();
            foreach (string item in names)
            {
                Human human = new Human();

                human.Name = item;

                humans1.Add(human);
            }


            Console.WriteLine("Humans sorted by name lenght \n");
            var query = (from nimi in humans1
                         orderby nimi.Name.Length ascending
                         select nimi).ToList();

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }
            var NameLenghts = from item in query
                           group item.Name.Length by item.Name.Length into y
                           select y;
            foreach (var item in NameLenghts)
            {
                if (item.Key != 0)
                {
                    Console.WriteLine("{1} name(s) consist of {0} letter(s)", item.Key, item.Count());
                }

            }

            Console.ReadLine();
        }
    }
}
