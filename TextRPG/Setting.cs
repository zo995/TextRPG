using System.Media;
using System.Reflection;

namespace TextRPG
{
    internal class Setting
    {
        public static int activeMedia = 1;
        public static void MenuSetting()
        {
            int number;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Настройки");
                    Console.WriteLine("1 - Вкл/Выкл музыки");
                    Console.WriteLine("0 - Выход");

                    number = Mechanics.ReadLineInt();
                    if (number < 2) { break; };
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода числа");
                    Console.WriteLine();
                }

                Console.Clear();
                switch (number)
                {
                    case 1:
                        if (activeMedia == 1)
                        {
                            activeMedia = 0;
                        }
                        else
                        {
                            activeMedia = 1;
                        }
                        Media.Soundtrack();
                        break;
                }
                if (number == 0) { break; }
            }
        }
    }
}