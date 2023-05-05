using System.Media;
using System.Reflection;

namespace TextRPG
{
    internal class Setting
    {
        public static int activeMedia = 1;
        public static void MenuSetting()
        {
            int number;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Настройки");
                    Console.WriteLine("1 - Вкл/Выкл музыки");
                    Console.WriteLine("0 - Выход");

                    number = Mechanics.ReadLineInt();
                    if (number < 2) { break; };
                    Console.Clear();
                    Console.WriteLine("Ошибка ввода числа");
                    Console.WriteLine();
                }

                Console.Clear();
                switch (number)
                {
                    case 1:
                        if (activeMedia == 1)
                        {
                            activeMedia = 0;
                        }
                        else
                        {
                            activeMedia = 1;
                        }
                        Setting.Media();
                        break;
                }
                if (number == 0) { break; }
            }
        }

        public static void Media()
        {

            List<string> musicFiles = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(x => x.EndsWith(".wav")).ToList();
            int currentTrackIndex = 0;
            bool isPlaying = true; // флаг, указывающий, проигрывается ли музыка в данный момент

            if (musicFiles.Count > 0)
            {
                string trackName = musicFiles[currentTrackIndex];
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(trackName))
                {
                    if (stream != null)
                    {
                        SoundPlayer player = new SoundPlayer(stream);
                        player.Play();

                        if (activeMedia == 0) { player.Stop(); }

                        player.SoundLocationChanged += (sender, eventArgs) =>
                        {
                            if (!player.IsLoadCompleted) // проверяем, завершено ли проигрывание текущего трека
                            {
                                return;
                            }

                            if (isPlaying) // проверяем, проигрывается ли музыка в данный момент
                            {
                                currentTrackIndex++;
                                if (currentTrackIndex >= musicFiles.Count)
                                {
                                    currentTrackIndex = 0;
                                }

                                trackName = musicFiles[currentTrackIndex];
                                using (Stream nextStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(trackName))
                                {
                                    if (nextStream != null)
                                    {
                                        player.SoundLocation = trackName;
                                        player.Stream = nextStream;
                                        player.Play();

                                        if (activeMedia == 0) { player.Stop(); }
                                    }
                                }
                            }
                        };
                    }
                }

            }
            /*
            SoundPlayer player = new(Properties.Resources.music_fon_1);
            if (activeMedia == 1)
            {
                player.PlayLooping();
            }
            else
            {
                player.Stop();
            }
        */
        }

    }
}

