using System;
using unit06_game.Game.Casting;
using unit06_game.Game.Scripting;
using Raylib_cs;


namespace unit06_game.Game.Casting
{
    public class Enemy : Actor
    {
        private int health;
        private int max_health;
        private int points;
        private Color color;
        private Point position;
        private Cast cast;
        private Point velocity = new Point(0, 0);
        /// <summary>
        /// Creates an instance of an enemy
        /// </summary>
        public Enemy(Cast cast)
        {
            this.position = new Point (10, Constants.MAX_Y / 2);
            this.cast = cast;
            SetText("U");
            SetPosition(position); 
            SetVelocity(new Point (5, 0));
            SetColor(new Color (200, 0, 0));
            SetHealth(0);
        }
        public override void MoveNext()
        {
            int x = ((position.GetX() + velocity.GetX()) + Constants.MAX_X) % Constants.MAX_X;
            int y = ((position.GetY() + velocity.GetY()) + Constants.MAX_Y) % Constants.MAX_Y;
            position = new Point(x, y);
        }

        public void SetHealth(int damage)
        {
            Stats stats = new Stats();
            max_health = stats.GetWave() * 100; 
            health = health - damage;
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetMaxHealth()
        {
            return max_health;
        }

        public Point GetHealthBarPosition()
        {
            Point HealthBarPosition = GetPosition().Add(new Point (-5, -15));
            return HealthBarPosition;
        }
    }
}