using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System.Threading.Tasks;
using System;

namespace unit06_game.Game.Scripting
{
    /// <summary>
    /// The objective of this class it to deal damage to the enemy that is closest to the tower.
    /// </summary>
    public class TowerDamage : Action
    {
        private double closest = 100000;
        private List<Enemy> enemies_in_range = new List<Enemy>();
        private Random random = new Random();
        private int crit = 0;
        /// <summary> 
        /// Constructs a new instance of TowerDamage.
        /// </summary>
        public TowerDamage()
        {
        } 
        public void Execute(Cast cast, Script script)
        {

            List<Enemy> enemies = cast.GetEnemies("enemy");
            List<Actor> crit_towers = cast.GetActors("crit_tower");
            List<Actor> fire_towers = cast.GetActors("fire_tower");
            List<Actor> poison_towers = cast.GetActors("poison_tower");
            
            foreach (Tower tower in crit_towers) {
                // Reset the closest value to the max tower range (so it doesn't get stuck at a certain spot)
                closest = tower.GetRange();
                // Get enemies in range of the tower
                enemies_in_range = tower.GetEnemiesInRange();
                if (enemies_in_range != null) {
                    foreach (Enemy enemy in enemies_in_range) {
                        // If the distance between the tower and the enemy is less than current closest
                        if (tower.GetPosition().Distance_From(enemy.GetPosition()) < closest) {
                            // Set the current closest to this new enemy
                            closest = tower.GetPosition().Distance_From(enemy.GetPosition());
                            // That enemy takes damage
                            
                            enemy.TakeDamage(tower.GetDamage());
                            // Critical strike just deals damage a second time
                            crit = random.Next(100);
                            if (tower.GetCritChance() > crit) {
                                enemy.TakeDamage(tower.GetDamage());
                            }
                            // For some reason this works with the enemies before they reach the closest threshold
                            // But they continue to take damage even after they are no longer the closest.
                            // I feel like that's as good as I can get it.
                        }
                    }
                }
            }
            foreach (Tower tower in fire_towers) {
                // This one just deals damage to everything in range
                enemies_in_range = tower.GetEnemiesInRange();
                if (enemies_in_range != null) {
                    foreach (Enemy enemy in enemies_in_range) {
                        enemy.TakeDamage(tower.GetDamage());
                    }
                }
            }
            foreach (Tower tower in poison_towers) {
                // Find some way to get poison damage
                closest = tower.GetRange();
                enemies_in_range =  tower.GetEnemiesInRange();
                if (enemies_in_range != null) {
                    foreach (Enemy enemy in enemies_in_range) {
                        if (tower.GetPosition().Distance_From(enemy.GetPosition()) < closest) {
                            closest = tower.GetPosition().Distance_From(enemy.GetPosition());
                            enemy.TakeDamage(tower.GetDamage());
                            enemy.AddPoison(tower.GetPoisonDamage());
                        }
                    }
                }
            }
            foreach (Enemy enemy in enemies) {
                enemy.TakeDamage(enemy.GetPoisonValue());
            }
        }
    }
}