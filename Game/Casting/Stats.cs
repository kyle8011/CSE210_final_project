using System.Collections.Generic;
namespace unit06_game.Game.Casting
{
    
    public class Stats : Actor
    {
        private int wave = 0;
        private int lives = 10;
        private int gold = 200;
        private bool inplay = false;
        private Cast cast;

        public Stats(Cast cast, int wave = 0, int lives = 10, int gold = 200)
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
            gold += 10 * wave;
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
        /// </summary>
        public bool InPlay()
        {
            //int num_alive = 0;
            List<Enemy> enemies = cast.GetEnemies("enemy");
            if (enemies.Count > 0)
            {
                inplay = true;
            }
            else 
            {
                inplay = false;
                AddWave();
            }
            return inplay;
        }
    }
}