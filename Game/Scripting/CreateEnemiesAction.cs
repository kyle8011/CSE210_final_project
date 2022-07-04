using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;

namespace unit06_game.Game.Scripting
{
    public class CreateEnemiesAction : Action
    {
        private int time = 0;
        public CreateEnemiesAction()
        {

        }
        public void Execute(Cast cast, Script script)
        {
            time += 1;
            Path path = (Path) cast.GetFirstActor("path");
            Stats stats = (Stats) cast.GetFirstActor("stats");
            List<Enemy> enemies = cast.GetEnemies("enemy");
            if (stats.InPlay() == false) {
                if (enemies.Count < (10 + stats.GetWave()) && time % 10 == 1){
                cast.AddEnemy("enemy", new Enemy(cast, path));
                }
            }
        }
    }
}