using System.Collections.Generic;
namespace unit06_game.Game.Casting
{
    
    public class Stats : Actor
    {
        private int wave;
        private int lives;
        private int gold;
        private bool inplay;
        private List<bool> is_alive = new List<bool>();
        private Cast cast;
        private int i;

        public Stats(Cast cast, int wave = 1, int lives = 10, int gold = 200)
        {
            this.wave = wave;
            this.lives = lives;
            this.gold = gold;
            this.cast = cast;
        }

        public void AddWave()
        {
            wave++;
        }

        public int GetWave()
        {
            return wave;
        }
        public void AddGold()
        {
            gold += 10 * wave;
        }

        public int GetGold()
        {
            return gold;
        }

        public bool InPlay()
        {
            int num_alive = 0;
            List<Enemy> enemies = cast.GetEnemies("enemy");
            for (i = 0; i <= enemies.Count; i++) {
                is_alive[i] = enemies[i].GetAliveStatus();
            }
            foreach(bool alive in is_alive)
            {
                if (alive)
                {
                    num_alive += 1;
                }
            }
            if (num_alive > 0)
            {
                inplay = true;
            }
            else {inplay = false;}
            return inplay;
        }
    }
}