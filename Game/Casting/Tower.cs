

namespace unit06_game.Game.Casting
{
    public class Tower : Actor
    {
        private Cast cast;
        private int damage = 1;
        private int range = 0;
        private int level = 1;

        public Tower(Cast cast)
        {
            this.cast = cast;
            SetPosition(new Point (Constants.MAX_X / 2 - 200, Constants.MAX_Y / 2 - 100));
            SetColor(new Color (0, 200, 0));
            SetRange(level);
            SetDamage(level);
        }

        public void SetDamage(int level)
        {
            damage = 1 * level;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetRange(int level)
        {
            range = 200 * level;
        }

        public int GetRange()
        {
            return range;
        }

    }
}