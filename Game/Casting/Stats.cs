using System.Collections.Generic;
namespace unit06_game.Game.Casting
{
    
    public class Stats : Actor
    {
        private int wave = 1;
        private int lives = 10;
        private int gold = 300;
        private bool inplay = true;
        private bool start = false;
        private int start_int = 0;
        private Cast cast;

        public Stats(Cast cast, int wave = 1, int lives = 10, int gold = 200)
        {
            this.wave = wave;
            this.lives = lives;
            this.gold = gold;
            this.cast = cast;
            
        }

        /// <summary>
        /// Subtracts one life.
        /// </summary>
        public void LoseLife()
        {
            lives--;
        }
        /// <summary>
        /// Gets the current value of lives.
        /// </summary>
        public int GetLives()
        {
            return lives;
        }
        /// <summary>
        /// Adds one to the wave number.
        /// </summary>
        public void AddWave()
        {
            wave++;
        }
        /// <summary>
        /// Gets the current wave number.
        /// </summary>
        public int GetWave()
        {
            return wave;
        }
        /// <summary>
        /// Adds (10*wave) gold.
        /// </summary>
        public void AddGold()
        {
            gold += 5 + (5 * wave);
        }
        public void SpendGold(int spent)
        {
            gold -= spent;
        }
        /// <summary>
        /// Returns the current gold value.
        /// </summary>
        public int GetGold()
        {
            return gold;
        }
        /// <summary>
        /// Tells if the wave has finished, returns false if
        /// all the enemies have died or crossed into the end zone.
        // / </summary>
        public bool InPlay()
        {
            List<Actor> fire_towers = cast.GetActors("fire_tower");
            List<Actor> crit_towers = cast.GetActors("crit_tower");
            List<Actor> poison_towers = cast.GetActors("poison_tower");
            List<Enemy> enemies = cast.GetEnemies("enemy");
            foreach (Tower tower in fire_towers) {
                if (tower.GetPlacedStatus()) {
                    start = true;
                }
            }
            foreach (Tower tower in crit_towers) {
                if (tower.GetPlacedStatus()) {
                    start = true;
                }
            }
            foreach (Tower tower in poison_towers) {
                if (tower.GetPlacedStatus()) {
                    start = true;
                }
            }
            if (enemies.Count > 0)
            {
                inplay = true;
            }
            else if (start)
            { 
                inplay = false;
                if (start_int > 0)
                {AddWave();}
                start_int ++;
            }
            return inplay;
        }
    }
}