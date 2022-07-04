using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Scripting;
using Raylib_cs;


namespace unit06_game.Game.Casting
{
    public class Enemy : Actor
    {
        private int health;
        private int max_health;
        private Point position = new Point(0, 0);
        private Point velocity = new Point(0, 0);
        private Cast cast;
        private Path path;
        private bool is_alive = true;
        /// <summary>
        /// Creates an instance of an enemy
        /// </summary>
        public Enemy(Cast cast, Path path)
        {
            this.position = new Point (10, Constants.MAX_Y / 2);
            this.cast = cast;
            this.path = path;
            //List<Point> points = path.GetPath();
            //foreach (Point point in points) {
            //    Point velocity = new Point();
                SetVelocity(new Point (5, 0));
            //}
            SetText("M");
            SetPosition(position); 
            
            SetColor(new Color (200, 0, 0));
            SetHealth(0);
        }
        //public override void MoveNext()
        //{
        //    //if (GetAliveStatus())
        //    //{
        //    int x = ((position.GetX() + velocity.GetX()) + Constants.MAX_X) % Constants.MAX_X;
        //    int y = ((position.GetY() + velocity.GetY()) + Constants.MAX_Y) % Constants.MAX_Y;
        //    position = new Point(x, y);
        //    //}
        //}

        public void SetHealth(int damage)
        {
            Stats stats = new Stats(cast);
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

        public bool GetAliveStatus()
        {
            if (health >= 1)// && GetPosition().GetX() < 10)
            {
                is_alive = true;
            }
            else {is_alive = false;}
            return is_alive;
        }
    }
}