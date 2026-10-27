using Adapter.Libs;

namespace Adapter.Adapters
{
    internal class Mp3PlayerAdapter : IPlayer
    {
        public void Play(string file)
        {
            Mp3Player mp3Player = new(file);
            mp3Player.Play(file);
        }
    }
}
