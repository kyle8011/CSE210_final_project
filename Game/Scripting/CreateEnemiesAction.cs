using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

namespace unit06_game.Game.Scripting
{
    public class CreateEnemiesAction : Action
    {
        private int time = 0;
        int i = 0;
        public CreateEnemiesAction()
        {

        }
        public async void Execute(Cast cast, Script script)
        {
            time += 1;
            Path path = (Path) cast.GetFirstActor("path");
            Stats stats = (Stats) cast.GetFirstActor("stats");
            List<Enemy> enemies = cast.GetEnemies("enemy");
            if (stats.InPlay() == false) 
            {
                //await Task.Delay(5000);
                for (i = 0; i < 9 + stats.GetWave(); i++)
                {
                    cast.AddEnemy("enemy", new Enemy(cast, path));
                    await Task.Delay(1500);
                }
            }
        }
    }
}