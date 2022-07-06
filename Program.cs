using unit06_game.Game.Casting;
using unit06_game.Game.Directing;
using unit06_game.Game.Scripting;
using unit06_game.Game.Services;

namespace unit06_game
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        public static void Main(string[] args)
        {
           
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("tower", new Tower(cast));
            cast.AddActor("stats", new Stats(cast));
            cast.AddActor("wave", new Display(cast, "wave"));
            cast.AddActor("gold", new Display(cast, "gold"));
            cast.AddActor("lives", new Display(cast, "lives"));
            //create path
            Path path = new Path();
            path.MakePath();

            // create the services
            KeyboardService keyboardService= new KeyboardService();
            VideoService videoService = new VideoService(false);
            MouseService mouseService = new MouseService();
            
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new CreateEnemiesAction());
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new MoveEnemiesAction());
            script.AddAction("update", new UpdateHudAction());
            script.AddAction("update", new TowerDamage());
            script.AddAction("output", new DrawActorsAction(videoService));
            script.AddAction("output", new DrawPathAction(videoService,path));
            //test mouse service
            script.AddAction("input", new ControlTowerAction(mouseService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }   
    }
}
