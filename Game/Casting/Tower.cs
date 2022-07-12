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
        private string type = "none";
        private int crit_chance = 0;
        private int poison_damage = 0;
        private bool placed = false;

        public Tower(Cast cast, string type)
        {
            this.cast = cast;
            this.type = type;
            if (type == "fire") {
                SetPosition(new Point (140, 80));
                SetColor(new Color (200, 0, 0));
            }
            else if (type == "crit") {
                SetPosition(new Point (80, 80));
                SetColor(new Color (0, 0, 200));
            }
            else if (type == "poison") {
                SetPosition(new Point (20, 80));
                SetColor(new Color (0, 200, 0));
            }
            //SetPosition(new Point (Constants.MAX_X / 2 - 200, Constants.MAX_Y / 2 - 100));
            //SetColor(new Color (0, 200, 0));
            SetRange(level);
            SetDamage(level);
        }

        public string GetKind() 
        {
            return type;
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

        public void PlaceTower()
        {
            placed = true;
        }
        
        public bool GetPlacedStatus()
        {
            return placed;
        }

        public int GetPrice()
        {
            List<Actor> fire_towers = cast.GetActors("fire_tower");
            List<Actor> crit_towers = cast.GetActors("crit_tower");
            List<Actor> poison_towers = cast.GetActors("poison_tower");
            if (type == "fire") {
                return (100 + (fire_towers.Count * 100));
            }            
            if (type == "crit") {
                return (100 + (crit_towers.Count * 100));
            }            
            if (type == "poison") {
                return (100 + (poison_towers.Count * 100));
            }            
            else {return 10000;}
        }

        public void SetDamage(int level)
        {
            if (type == "fire") {
                damage = 50 * level;
            }
            else if (type == "crit") {
                damage = 100 * level;
                crit_chance = 30 + (5 * level);
            }
            else if (type == "poison") {
                damage = 10 * level;
                poison_damage = 1 * level;
            }
        }

        public int GetCritChance() 
        {
            return crit_chance;
        }

        public int GetPoisonDamage()
        {
            return poison_damage;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void SetRange(int level)
        {
            range = 150 + (25 * level);
        }

        public int GetRange()
        {
            return range;
        }

        public int GetLevel()
        {
            return level;
        }

    }
}