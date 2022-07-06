using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System.Threading.Tasks;

namespace unit06_game.Game.Scripting
{
    public class TowerDamage : Action
    {
        bool condition_x = false;
        bool condition_y = false;
        public TowerDamage()
        {

        }
        public void Execute(Cast cast, Script script)
        {
            List<Enemy> enemies = cast.GetEnemies("enemy");
            List<Actor> towers = cast.GetActors("tower");
            foreach (Enemy enemy in enemies) {
                foreach (Tower tower in towers) {
                    condition_x = (enemy.GetPosition().GetX() <= tower.GetPosition().GetX() + tower.GetRange()) && (enemy.GetPosition().GetX() <= tower.GetPosition().GetX() - tower.GetRange());
                    condition_y = (enemy.GetPosition().GetY() <= tower.GetPosition().GetY() + tower.GetRange()) && (enemy.GetPosition().GetY() <= tower.GetPosition().GetY() - tower.GetRange());
                    if (condition_x && condition_y) {
                        enemy.TakeDamage(tower.GetDamage());
                    } 
                }
            }
        }
    }
}