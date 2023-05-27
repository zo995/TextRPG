using System.Media;
using System.Reflection;

namespace TextRPG
{
    internal class Media
    {
        public static void Soundtrack()
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

                        if (Setting.activeMedia == 0) { player.Stop(); }

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

                                        if (Setting.activeMedia == 0) { player.Stop(); }
                                    }
                                }
                            }
                        };
                    }
                }

            }
            /*
            SoundPlayer player = new(Properties.Resources.music_fon_1);
            if (Setting.activeMedia == 1)
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
