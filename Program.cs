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
            VideoService videoService = new VideoService(false);
            cast.AddActor("stats", new Stats(cast));
            cast.AddActor("shop", new Display(cast, "poison", videoService));
            cast.AddActor("shop", new Display(cast, "critical", videoService));
            cast.AddActor("shop", new Display(cast, "fire", videoService));
            cast.AddActor("tower_stats", new Display(cast, "tower_stats", videoService));
            cast.AddActor("wave", new Display(cast, "wave", videoService));
            cast.AddActor("gold", new Display(cast, "gold", videoService));
            cast.AddActor("lives", new Display(cast, "lives", videoService));
            //cast.AddActor("menu",new Display)
            //create path
            Path path = new Path();
            path.MakePath();

            // create the services
            KeyboardService keyboardService= new KeyboardService();
            
            MouseService mouseService = new MouseService();
            
           
            // create the script
            Script script = new Script();
            script.AddAction("update", new CreateEnemiesAction());
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new MoveEnemiesAction());
            script.AddAction("update", new UpdateHudAction());
            script.AddAction("update", new TowerDamage());
            script.AddAction("output", new DrawActorsAction(videoService));
            script.AddAction("output", new DrawPathAction(videoService,path));
            script.AddAction("input", new ControlTowerAction(mouseService, keyboardService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }   
    }
}
