using System;
using Lab_library;

namespace UI_test
{
    class Program
    {
        static void Main(string[] args)
        {
            BuisnesLayer bl = new BuisnesLayer();
            string login = Console.ReadLine();
            string password = Console.ReadLine();
            bl.passFunction(login, password);
        }
    }
}
