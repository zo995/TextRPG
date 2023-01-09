using System.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG
{
    internal class Setting
    {
        public static int activeMedia=1;
        public static void MenuSetting()
        {
            int number;
            string text;
            while (true)
            {
                Console.WriteLine("Настройки");
                Console.WriteLine("1-Вкл/Выкл музыки");
                Console.WriteLine("2-Выход");
                text = Console.ReadLine();
                if (int.TryParse(text, out int proxod))
                {
                    if (proxod <= 0) { proxod = 1; }
                    number = proxod;
                    break;
                }
                Console.Clear();
                Console.WriteLine("Ошибка ввода");
            }
            Console.Clear();
            switch (number)
            {
                case 1: 
                    if (activeMedia==1) 
                    {
                        activeMedia = 0;
                    }
                    else 
                    { 
                        activeMedia = 1;
                    }
                    Setting.Media();
                    Setting.MenuSetting();
                    break;

                case 2:
                    Menu.Base();
                    break;
            }
        }
        public static void Media()
        {
            SoundPlayer player = new()
            {
                SoundLocation = "Media\\nejnaya-melodiya-dlya-sna.wav"
            };
            if (activeMedia == 1)
            {
                player.PlayLooping();
            }
            else
            {
                player.Stop();
            }
        }
    }
}
