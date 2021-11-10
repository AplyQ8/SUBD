using System;
using DataBase;

namespace ConsoleApp
{
    class UI
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            logic.DataCreation();
            Console.WriteLine(logic.Print());
            bool endPoint = true;
            while (endPoint)
            {
                Console.WriteLine("нажмите 1, если хотите проверить пару\n");
                Console.WriteLine("нажмите 0, если хотите выйти");
                int switch_on = Convert.ToInt32(Console.ReadLine());
                switch (switch_on)
                {
                    case 1:
                        {
                            Console.WriteLine("Выберите номер пары, которую хотите проверить");
                            int num = int.Parse(Console.ReadLine());
                            Console.WriteLine(logic.Suggestion(num-1));
                            break;
                        }
                    case 0:
                        {
                            endPoint = false;
                           
                            break;
                        }
                }    
            }
        }
    }
}
