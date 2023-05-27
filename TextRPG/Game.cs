
namespace TextRPG
{
    internal class Game
    {
        public static int itog = 0;
        public static void Introduction()
        {
            Console.WriteLine("Тут должно быть вступление, но я его ещё не придумал");
            Console.WriteLine("Нажмите что-нибудь для продолжения");
            Console.ReadKey();
            Console.Clear();

            Battle();
        }

        public static void Battle()
        {
            int number;

            Mechanics.MobGenerator();

            do
            {
                while (true)
                {
                    Console.WriteLine($"Общее число убитых врагов: { UserData.killUnit}");
                    Console.WriteLine("Ваши характеристики");
                    Console.WriteLine($"HP = {UserData.HP} Power = {(UserData.userPower + 2)} - {(UserData.userPower + 7)}");
                    Console.WriteLine("Характеристики врага");
                    Console.WriteLine($"Имя: {MobData.mobName}");
                    Console.WriteLine($"Уровень: {MobData.mobLevel}");
                    Console.WriteLine($"HP = {MobData.mobHP}");
                    Console.WriteLine("Выберте один из вариантов");
                    Console.WriteLine("1 - Бой");
                    Console.WriteLine($"2 - Защищаться (Шанс {Mechanics.minSliv}%)");
                    Console.WriteLine("3 - Открыть инвентарь");
                    Console.WriteLine("0 - Выйти");

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
                        Mechanics.Attac();
                        break;

                    case 2:
                        Mechanics.Sliv();
                        break;
                    case 3:
                        Mechanics.Inventory();
                        break;
                    case 0:
                        itog = 1;
                        break;
                }
                if (UserData.HP <= 0)
                {
                    itog = 1;
                    break;
                }
                if (MobData.mobHP <= 0)
                {
                    Mechanics.DeadUnit();
                }
            }
            while (itog != 1);
            
            Console.Clear();
            Console.WriteLine($"В общей сложности вы убили: {UserData.killUnit}");
            Console.WriteLine("Ваши характеристики");
            Console.WriteLine($"HP= {UserData.HP}");
            if (number != 0) { Console.WriteLine("Game over"); }
            Console.ReadKey();
            Console.Clear();
        }
    }
}

