using System.Collections.Generic;

namespace unit06_game.Game.Casting
{
    public class Tower : Actor
    {
        private Cast cast;
        private List<Enemy> enemies_in_range;
        private List<Enemy> none = null;
        private bool condition_x;
        private bool condition_y;
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

        public List<Enemy> GetEnemiesInRange()
        {
            List<Enemy> enemies = cast.GetEnemies("enemy");
            enemies_in_range = cast.GetEnemies("enemy");
            foreach (Enemy enemy in enemies) {
                condition_x = (enemy.GetPosition().GetX() <= GetPosition().GetX() + GetRange()) && (enemy.GetPosition().GetX() >= GetPosition().GetX() - GetRange());
                condition_y = (enemy.GetPosition().GetY() <= GetPosition().GetY() + GetRange()) && (enemy.GetPosition().GetY() >= GetPosition().GetY() - GetRange());
                if (condition_x && condition_y) {
                    enemies_in_range.Add(enemy);
                }
                else {
                    if (enemies_in_range != null) {
                        enemies_in_range.Remove(enemy);
                    }
                }    
            }
            if (enemies_in_range != null) {
                return enemies_in_range;
            }
            else {return none;}
            
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