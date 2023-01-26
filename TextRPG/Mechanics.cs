using System.Media;
using System.Resources;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG
{
    internal class Mechanics
    {
        public static int minSliv, mobID, minRN, maxRN, sliv;

        public static int[] inventory = new int[10];
        public static int Rand()
        {
            Random random= new();
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
                UserData.HP -= 1;
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
            string[] mobList = {"Гоблин", "Змея", "Крыса"};
            int[] minLevel = {1,1,1};
            int[] maxLevel = {5,5,5};
            int[] slivMob = {20, 30, 50};
            int[] mobHP = {50, 30, 20};

            MobData.mobHP = mobHP[mobID];

            minRN = 0;
            maxRN= 2;
            mobID = Rand();

            MobData.mobName = mobList[mobID];

            minRN = minLevel[mobID];
            maxRN = maxLevel[mobID];
            MobData.mobLevel = Rand();

            minSliv = slivMob[mobID];
        }

        public static void Attac()
        {
            minRN = 1;
            maxRN = 100;
            sliv = Rand();
            if (minSliv <= sliv)
            {
                minRN= 2;
                maxRN = 7;
                int damage = Rand();

                MobData.mobHP -= damage;
                Console.WriteLine("Повезло, вы смогли ударить врага на " + damage + " урон");
            }
            else
            {
                minRN = 1;
                maxRN = 4;
                int damage = Rand();

                UserData.HP -= damage;

                Console.WriteLine("Не повезло, враг ударил вас в ответ на " + damage + " урон");
            }
            Console.WriteLine();
        }
        
        public static void Inventory()
        {
            for(int i=0; i< inventory.Length; i++)
            {
                if (inventory[i] == 0)
                {
                    Console.WriteLine("Пусто");
                }
                else if (inventory[i] == 1)
                {
                    Console.WriteLine("Зелье лечения");
                }
            }
            Console.WriteLine("Нажмите что-либо, чтобы выйти из инвенторя");
            Console.ReadKey();
            Console.Clear();
        }

        public static int ReadLineInt()
        {
            int number;
            while (true)
            {
                string text = Console.ReadLine();
                if (int.TryParse(text, out int proxod))
                {
                    if (proxod <= 0) { proxod = 1; }
                    number = proxod;
                    break;
                }
                Console.WriteLine("Ошибка ввода");
            }
            return number;
        }
    }
}
