﻿
namespace TextRPG
{
    internal class Game
    {
        public static int itog = 0, i;
        public static void Introduction()
        {
            Console.WriteLine("Тут должно быть вступление, но я его ещё не придумал");
            Console.WriteLine("Нажмите что-нибудь для продолжения");
            Console.ReadKey();
            Console.Clear();



            Battle1();
        }

        public static void Battle1()
        {
            int number;

            Mechanics.MobGenerator();

            do
            {
                while (true)
                {
                    Console.WriteLine($"Общее число убитых врагов: { UserData.killUnit}");
                    Console.WriteLine("Ваши характеристики");
                    Console.WriteLine($"HP = {UserData.HP} Power = {(2 + UserData.userPower)} - {(7 + UserData.userPower)}");
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
                    Console.Clear();
                    Console.WriteLine($"Молодец, ты убил {MobData.mobName} {MobData.mobLevel} уровня");
                    UserData.killUnit++;
                    Mechanics.minRN= 1;
                    Mechanics.maxRN= 100;
                    int loot = Mechanics.Rand();
                    if (loot <= 15)
                    {
                        i = 0;
                        Console.WriteLine("Вам выпало: Зелье лечения");
                        while (true)
                        {
                            if (Mechanics.inventory[i] == 0)
                            {
                                Mechanics.inventory[i] = 1;
                                break;
                            }
                            if (i== Mechanics.inventory.Length- 1)
                            {
                                Console.WriteLine("Предмет не получен");
                                break;
                            }
                            i++;
                        }
                    }
                    if (loot <= 10)
                    {
                        i = 0;
                        Console.WriteLine("Вам выпало: Деревянный меч");
                        while (true)
                        {
                            if (Mechanics.inventory[i] == 0)
                            {
                                Mechanics.inventory[i] = 2;
                                break;
                            }
                            if (i == Mechanics.inventory.Length - 1)
                            {
                                Console.WriteLine("Предмет не получен");
                                break;
                            }
                            i++;
                        }
                    }
                    Console.WriteLine("Нажмите что-нибудь, чтобы продолжить");
                    Console.ReadKey();
                    Console.Clear();
                    Mechanics.MobGenerator();
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

