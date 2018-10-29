using System;

namespace ChickenFarmer.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(AppContext.BaseDirectory);
            game.Run();
        }
    }
}
