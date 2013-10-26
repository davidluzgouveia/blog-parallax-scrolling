using System;

namespace ParallaxScrolling
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ParallaxScrollingGame game = new ParallaxScrollingGame())
            {
                game.Run();
            }
        }
    }
#endif
}

