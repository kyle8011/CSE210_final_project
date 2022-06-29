using System;
using UNIT06_GAME.Directing;
using UNIT06_GAME.Services;

namespace Unit06
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
