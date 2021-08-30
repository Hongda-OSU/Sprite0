using System;

namespace Sprite0
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Mario())
                game.Run();
        }
    }
}
