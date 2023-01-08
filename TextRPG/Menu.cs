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
                    Console.WriteLine("2 - Настройки");
                    text = Console.ReadLine();
                    if (int.TryParse(text, out int proxod))
                    {
                        if (proxod <= 0) { proxod = 1; }
                        number = proxod;
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода");
                }
            if (number < 3) { break; };
                Console.Clear();
                Console.WriteLine("Ошибка ввода");
            }
            Console.Clear();

            switch (number)
            {
                case 1:
                    Game.Introduction();
                break;
                
                case 2:
                    Setting.MenuSetting();
                break;
            }
        }
    }
}
