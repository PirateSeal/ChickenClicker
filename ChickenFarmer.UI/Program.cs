using System;

namespace ChickenFarmer.UI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            GameLoop game = new GameLoop();
            game.Run();
        }
    }
}
