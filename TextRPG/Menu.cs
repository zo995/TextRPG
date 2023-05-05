
namespace TextRPG
{
    internal class Menu
    {
        public static void Base()
        {
            int number;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Выберите нужный пункт и введите его номер");
                    Console.WriteLine("1 - Старт");
                    Console.WriteLine("2 - Настройки");
                    Console.WriteLine("0 - Выход");

                    number = Mechanics.ReadLineInt();
                    if (number < 3) { break; };
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода числа");
                    Console.WriteLine();
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
                if (number == 0) { break; }
            }
        }
    }
}
