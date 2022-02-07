using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager
{
    public static class Modules
    {
        public static void Welcome()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|                       |");
            Console.WriteLine("|       Welcome!        |");
            Console.WriteLine("|      Hit Enter        |");
            Console.WriteLine("|                       |");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        public static void ShowMenu()
        {
            Console.Clear();
            var pos = 1;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("|Id |   ServiceName   |            Email               |  Password  |");
            foreach (var s in Services.List)
            {
                Console.WriteLine($"| {pos++} | {s.Service.PadRight(15)} | {s.Email.PadRight(30)} | ********** |");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
