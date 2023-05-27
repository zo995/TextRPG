namespace TextRPG
{
    internal class StartGame
    {
        static void Main()
        {
            Media.Soundtrack();

            Console.WriteLine("23.10.2022 Начало работы");
            Console.WriteLine("Автор Zo995");
            Console.WriteLine("Нажмите что-нибудь для продолжения");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Назови себя странник(Пока не на что не влияет)");
            UserData.nameHero = Console.ReadLine();
            if (UserData.nameHero == "") { UserData.nameHero = "User"; }
            if (UserData.nameHero == "Zo995") { Mechanics.admin = 1; }
            Console.Clear();
            Menu.Base();
        }
    }
}