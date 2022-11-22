using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Menu
    {
        public static void Base()
        {
            int number;
            string text;

            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Выберите нужный пункт и введите его номер");
                    Console.WriteLine("1 - Старт");
                    text = Console.ReadLine();
                    if (int.TryParse(text, out int proxod))
                    {

                        number = proxod;
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода");
                }
            if (number < 2) { break; };
                Console.Clear();
                Console.WriteLine("Ошибка ввода");
            }
            Console.Clear();

            switch (number)
            {
                case 1:
                    Game.Introduction();

                break;
            }
        }
    }
}
