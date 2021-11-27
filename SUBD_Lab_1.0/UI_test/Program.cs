using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DandT_library;

namespace UI_test
{
    class Program
    {
        static void Main(string[] args)
        {
            BuisnessLayer bl = new BuisnessLayer();
            string login = Console.ReadLine();
            string password = Console.ReadLine();
            string str = bl.passFunction(login, password);
            Console.WriteLine(str);
            Console.ReadKey();
            //bl.UserRegistration("Bob", "Marley");
            //Console.ReadKey();
            
        }
    }
}
