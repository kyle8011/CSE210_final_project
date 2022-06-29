using System;
using unit06_game.Directing;
using unit06_game.Services;

namespace Unit06_game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}
