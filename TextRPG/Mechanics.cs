using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Mechanics
    {
        public static int minSliv, mobID, minRN, maxRN, sliv;

        public static int Rand()
        {
            Random random= new Random();
            int i = random.Next(minRN, maxRN);
            return i;
        }

        public static int Sliv()
        {
            int i = 0;
            minRN = 1;
            maxRN = 100;
            sliv = Rand();
            if (minSliv <= sliv)
            {
                UserData.HP = UserData.HP - 1;
                Console.WriteLine("Неудача. вы потеряли 1hp");
            }
            else
            {
                Console.WriteLine("Повезло, вы смогли увернуться");
                i = 1;
            }
            Console.WriteLine();
            return i;
        }

        public static void MobGenerator()
        {
            string[] MobList = {"Гоблин", "Змея", "Крыса" };
            int[] MinLevel = {1,1,1};
            int[] MaxLevel = {5,5,5};
            int[] SlivMob = {20, 30, 50};

            minRN = 0;
            maxRN= 2;
            mobID = Rand();

            MobData.mobName = MobList[mobID];

            minRN = MinLevel[mobID];
            maxRN = MaxLevel[mobID];
            MobData.mobLevel = Rand();

            minSliv = SlivMob[mobID];
        }

        public static void Attac()
        {
            minRN = 1;
            maxRN = 100;
            sliv = Rand();
            if (minSliv <= sliv)
            {
                MobData.mobHP = MobData.mobHP - 5;
                Console.WriteLine("Повезло, вы смогли ударить врага на 5 урон");
            }
            else
            {
                Console.WriteLine("Не повезло, враг ударил вас в ответ на 3 урон");
                UserData.HP = UserData.HP - 3;
            }
            Console.WriteLine();
        }
        
    }
}
