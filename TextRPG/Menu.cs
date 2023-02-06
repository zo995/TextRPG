
namespace TextRPG
{
    internal class Menu
    {
        public static void Base()
        {
            int number;

            while (true)
            {
                Console.WriteLine("Выберите нужный пункт и введите его номер");
                Console.WriteLine("1 - Старт");
                Console.WriteLine("2 - Настройки");
                Console.WriteLine("3 - Выход");

                number = Mechanics.ReadLineInt();
                if (number < 4) { break; };
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
                case 3:
                    
                    break;
            }
        }
    }
}
