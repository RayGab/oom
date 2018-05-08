using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string mystring;
            Console.WriteLine("Hello World\n");
            Console.WriteLine("Bitte geben Sie einen Buchstaben ein:\n");

            mystring = Console.ReadLine();
            Console.WriteLine("Danke für die Eingabe. \n");
            Console.WriteLine("Ihre Eingabe war :"+mystring);
        }
    }
}
