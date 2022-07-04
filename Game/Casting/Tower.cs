

namespace unit06_game.Game.Casting
{
    public class Tower : Actor
    {
        private Cast cast;
        private int damage = 0;
        private int range = 0;
        private int level = 1;
        public Tower(Cast cast)
        {
            this.cast = cast;
            SetPosition(new Point (Constants.MAX_X / 2, Constants.MAX_Y / 2 - 100));
            SetColor(new Color (0, 200, 0));
        }

        public void SetDamage()
        {
            damage = 40 * level;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetRange()
        {
            range = 200 * level;
        }

        public int GetRange()
        {
            return range;
        }

    }
}