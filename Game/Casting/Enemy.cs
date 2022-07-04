using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Scripting;
using System;
using Raylib_cs;


namespace unit06_game.Game.Casting
{
    public class Enemy : Actor
    {
        private int health = 10;
        private int max_health = 10;
        private Point position = new Point(0, 0);
        private Cast cast;
        private Path path;
        private Stats stats;
        private bool is_alive = true;
        /// <summary>
        /// Creates an instance of an enemy
        /// </summary>
        public Enemy(Cast cast, Path path)
        {
            this.position = new Point (10, Constants.MAX_Y / 2);
            this.cast = cast;
            this.path = path;
            this.stats = (Stats) cast.GetFirstActor("stats");
            //List<Point> points = path.GetPath();
            //foreach (Point point in points) {
            //    Point velocity = new Point();
                SetVelocity(new Point (5, 0));
            //}
            SetText("M");
            SetPosition(position); 
            
            SetColor(new Color (200, 0, 0));
            SetMaxHealth();
        }
        /// <summary>
        /// Reduces the current health of the enemy, takes damage as an input.
        /// </summary>
        public void TakeDamage(int damage)
        {
            health = health - damage;
        }
        /// <summary>
        /// Sets the max health of the enemy and sets current health to max.
        /// </summary>
        public void SetMaxHealth()
        {
            max_health = stats.GetWave() * 100; 
            health = max_health;
        }
        /// <summary>
        /// Gets the current health of the enemy.
        /// </summary>
        public int GetHealth()
        {
            return health;
        }
        /// <summary>
        /// Gets the max health of the enemy.
        /// </summary>        
        public int GetMaxHealth()
        {
            return max_health;
        }
        /// <summary>
        /// Gets the position of the health bar.
        /// </summary>
        public Point GetHealthBarPosition()
        {
            Point HealthBarPosition = GetPosition().Add(new Point (-5, -15));
            return HealthBarPosition;
        }
        /// <summary>
        /// Gets the status of the enemy, whether it is alive or not
        /// death conditions are less than 1 hp or 50 spaces from the max_x
        /// </summary>
        public bool GetAliveStatus()
        {
            if (health >= 1 && GetPosition().GetX() < Constants.MAX_X - 50)
            {
                is_alive = true;
            }
            else if (health < 1)
            {
                is_alive = false;
                stats.AddGold();

            }
            else 
            {
                stats.LoseLife();
                Console.WriteLine(stats.GetLives());
                cast.RemoveEnemy("enemy", this);
            }
            return is_alive;
        }
    }
}