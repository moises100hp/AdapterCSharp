using Adapter.Libs;

namespace Adapter.Adapters
{
    internal class Mp4PlayerAdapter : IPlayer
    {
        public void Play(string file)
        {
            Mp4Player.Executar(file);
        }
    }
}
