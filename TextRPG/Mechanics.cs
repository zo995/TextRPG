using System.Media;
using System.Resources;

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
                MobData.mobHP -= 5;
                Console.WriteLine("Повезло, вы смогли ударить врага на 5 урон");
            }
            else
            {
                Console.WriteLine("Не повезло, враг ударил вас в ответ на 3 урон");
                UserData.HP -= 3;
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
            }
            Console.WriteLine("Нажмите что-либо, чтобы выйти из инвенторя");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Media()
        {
            SoundPlayer player = new()
            {
                SoundLocation = "Media\\nejnaya-melodiya-dlya-sna.wav"
            };
            player.PlayLooping();
        }
    }
}
