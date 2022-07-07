using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System.Threading.Tasks;
using System;

namespace unit06_game.Game.Scripting
{
    public class TowerDamage : Action
    {
        private int i;
        private bool condition_x = false;
        private bool condition_y = false;
        private bool first_enemy = true;
        private List<Enemy> enemies_in_range = new List<Enemy>();
        public TowerDamage()
        {

        }
        public void Execute(Cast cast, Script script)
        {

            List<Enemy> enemies = cast.GetEnemies("enemy");
            List<Actor> towers = cast.GetActors("tower");
            
            foreach (Tower tower in towers) {
                for (i = 0; i < enemies.Count; i++) {
                    condition_x = (enemies[i].GetPosition().GetX() <= tower.GetPosition().GetX() + tower.GetRange()) && (enemies[i].GetPosition().GetX() >= tower.GetPosition().GetX() - tower.GetRange());
                    condition_y = (enemies[i].GetPosition().GetY() <= tower.GetPosition().GetY() + tower.GetRange()) && (enemies[i].GetPosition().GetY() >= tower.GetPosition().GetY() - tower.GetRange());
                    if (condition_x && condition_y && first_enemy) {
                        //enemies_in_range.Add(enemies[i]);
                        enemies[i].TakeDamage(tower.GetDamage());
                    } 
                }
            }
            //foreach (Enemy enemy in enemies_in_range) {
            //    first_enemy = (enemy.GetPosition().GetX() > each(enemy));
            //    if (first_enemy)
            //}
        }
    }
}