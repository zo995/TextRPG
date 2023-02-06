
namespace TextRPG
{
    internal class Mechanics
    {
        public static int minSliv, mobID, minRN, maxRN, sliv, number, numberC;

        public static string nameItem;

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
            while (true)
            {


                while (true)
                {
                    foreach(int slot in inventory)
                    {
                        switch (slot)
                        {
                            case 0: Console.WriteLine("Пусто"); break;
                            case 1: Console.WriteLine("Зелье лечения"); break;
                        }
                    }
                    Console.WriteLine("1-10 - Выбрать предмет");
                    Console.WriteLine("0 - Назад");

                    while (true)
                    {
                        string text = Console.ReadLine();
                        if (int.TryParse(text, out int proxod))
                        {
                            if (proxod < 0) { proxod = 0; }
                            number = proxod;
                            break;
                        }
                        Console.WriteLine("Ошибка ввода");
                    }
                    if (number < 11) { break; }
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода числа");
                    Console.WriteLine(" ");
                }
                Console.Clear();
                if (number == 0)
                {
                    break;
                }

                if (inventory[number - 1] == 0)
                {
                    Console.WriteLine("Ты выбрал пустоту");
                    Console.WriteLine();
                    Inventory();
                }
                else
                {
                    while (true)
                    {
                        foreach (int slot in inventory)
                        {
                            switch (slot)
                            {
                                case 1: Console.WriteLine("Зелье лечения"); break;
                            }
                        }
                        Console.WriteLine("Выбран предмет: " + nameItem);
                        numberC = number - 1;
                        Console.WriteLine("Теперь выбери, что с ним делать");
                        Console.WriteLine("1 - Использовать");
                        Console.WriteLine("2 - Назад");

                        number = ReadLineInt();
                        Console.Clear();
                        if (number < 3) { break; };
                        Console.WriteLine("Ошибка ввода числа");
                        Console.WriteLine();
                    }
                    switch (number)
                    {
                        case 1:
                            foreach (int slot in inventory)
                            {
                                switch (slot)
                                {
                                    case 1:
                                        Console.WriteLine("Ваш уровень здоровья увеничен на 20");
                                        UserData.HP += 20;
                                        if (UserData.HP >= 100) { UserData.HP = 100; }
                                        inventory[numberC] = 0;
                                        break;
                                }
                            }
                            Console.WriteLine("Использовано: " + nameItem);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine();
                            Inventory();
                            break;
                    }
                }
            }
        }

        public static int ReadLineInt()
        {
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
