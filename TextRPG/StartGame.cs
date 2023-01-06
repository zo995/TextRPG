namespace TextRPG
{
    internal class StartGame
    {
        static void Main(string[] args)
        {
            Mechanics.Media();
            Console.WriteLine("23.10.2022 Начало работы");
            Console.WriteLine("Автор Zo995");
            Console.WriteLine("Нажмите что-нибудь для продолжения");
            Console.ReadKey();
            Console.Clear();
            Menu.Base();
        }
    }
}