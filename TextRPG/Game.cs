﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            Game.Battle1();
        }

        public static void Battle1()
        {
            int number;

            Mechanics.MobGenerator();
            Console.WriteLine("О нет, вы повстречали " + MobData.mobName + " " + MobData.mobLevel + " уровня");
            Console.WriteLine("Нажмите что-нибудь для продолжения");
            Console.ReadKey();
            Console.Clear();

            do
            {
                while (true)
                {
                    
                    Console.WriteLine("Ваши характеристики");
                    Console.WriteLine("HP=" + UserData.HP);
                    Console.WriteLine("Характеристики врага");
                    Console.WriteLine("Имя: " + MobData.mobName);
                    Console.WriteLine("Уровень: " + MobData.mobLevel);
                    Console.WriteLine("HP=" + MobData.mobHP);
                    Console.WriteLine("Выберте один из вариантов");
                    Console.WriteLine("1-Бой");
                    Console.WriteLine("2-Защищаться(Шанс" + Mechanics.minSliv + "%)");
                    Console.WriteLine("3-Открыть инвентарь");

                    number = Mechanics.WriteLineInt();
                    if (number < 4) { break; };
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода");
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
                }
                if (UserData.HP <= 0)
                {
                    itog = 1;
                    break;
                }
                if (MobData.mobHP <= 0)
                {
                    Console.WriteLine("Молодец, ты убил " + MobData.mobName + " " + MobData.mobLevel + " уровня");
                    Console.ReadKey();
                    Console.Clear();
                    Game.Battle1();
                }
            }
            while (itog != 1);
        
            Console.Clear();
            Console.WriteLine("Ваши характеристики");
            Console.WriteLine("HP=" + UserData.HP);
            Console.WriteLine("Game over");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

