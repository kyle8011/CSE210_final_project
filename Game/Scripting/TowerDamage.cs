using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System.Threading.Tasks;
using System;

namespace unit06_game.Game.Scripting
{
    public class TowerDamage : Action
    {
        //private int i;
        //private bool condition_x = false;
        //private bool condition_y = false;
        private double closest = 100000;
        //private Enemy closest_enemy;
        private List<Enemy> enemies_in_range = new List<Enemy>();
        //private List<Enemy> closest_enemies = new List<Enemy>();
        public TowerDamage()
        {

        }
        public void Execute(Cast cast, Script script)
        {

            List<Enemy> enemies = cast.GetEnemies("enemy");
            List<Actor> towers = cast.GetActors("tower");
            
            
            foreach (Tower tower in towers) {
                //private List<Enemy> enemies_in_range = new List<Enemy>();
                closest = tower.GetRange();
                enemies_in_range = tower.GetEnemiesInRange();
                if (enemies_in_range != null) {
                    foreach (Enemy enemy in enemies_in_range) {
                        if (tower.GetPosition().Distance_From(enemy.GetPosition()) < closest) {
                            closest = tower.GetPosition().Distance_From(enemy.GetPosition());
                            enemy.TakeDamage(tower.GetDamage());
                        }
                        //enemy.TakeDamage(tower.GetDamage());
                    }
                }
            }
        }
    }
}