namespace Adapter.Libs
{
    public class Mp3Player
    {
        private string File = "";

        public Mp3Player()
        {

        }

        public Mp3Player(string file)
        {
            File = file;
        }

        public void Play(string File)
        {
            System.Console.WriteLine($"Playing mp3 file: {File}");
        }
    }
}
