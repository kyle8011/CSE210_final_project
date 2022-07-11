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
<<<<<<< HEAD
            //cast.AddActor("fire_tower", new Tower(cast, "fire"));         //adding tower
            //cast.AddActor("crit_tower", new Tower(cast, "crit"));         //adding tower
            //cast.AddActor("poison_tower", new Tower(cast, "poison"));     //adding tower
=======
<<<<<<< HEAD
            //cast.AddActor("fire_tower", new Tower(cast, "fire"));
            //cast.AddActor("crit_tower", new Tower(cast, "crit"));
=======
            cast.AddActor("fire_tower", new Tower(cast, "fire"));
            cast.AddActor("crit_tower", new Tower(cast, "crit"));
>>>>>>> c9bb57a6654f3cc48975cf3051e0354fbb54adb3
            cast.AddActor("poison_tower", new Tower(cast, "poison"));
>>>>>>> 40f73c149585c573417617abaaeed08dda6d5a80
            cast.AddActor("stats", new Stats(cast));
            cast.AddActor("shop", new Display(cast, "poison"));
            cast.AddActor("shop", new Display(cast, "critical"));
            cast.AddActor("shop", new Display(cast, "fire"));
            cast.AddActor("wave", new Display(cast, "wave"));
            cast.AddActor("gold", new Display(cast, "gold"));
            cast.AddActor("lives", new Display(cast, "lives"));
            //cast.AddActor("menu",new Display)
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
            script.AddAction("input", new ControlTowerAction(mouseService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }   
    }
}
