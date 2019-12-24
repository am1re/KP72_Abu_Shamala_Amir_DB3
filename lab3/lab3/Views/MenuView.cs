using System;

namespace lab3.Views
{
    internal static class MenuView
    {
        public static Entities ShowEntities()
        {
            Console.Clear();
            Console.WriteLine("[1] - Person");
            Console.WriteLine("[2] - Car");
            Console.WriteLine("[3] - Accident");
            Console.WriteLine("[0] - Exit");
            return (Entities) GetNum(0, 3);
        }

        private static int GetNum(int downLimit, int upLimit)
        {
            int number;
            while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out number) 
                   || number < downLimit || number > upLimit)
                Console.WriteLine("Wrong input!");
            return number;
        }
    }
}
