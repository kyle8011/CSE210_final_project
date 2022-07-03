using unit06_game.Game.Casting;
namespace unit06_game.Game.Casting
{
    
    public class Stats : Actor
    {
        private int wave;
        private int lives;
        private int gold;

        public Stats(int wave = 1, int lives = 10, int gold = 200)
        {
            this.wave = wave;
            this.lives = lives;
            this.gold = gold;
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
    }
}