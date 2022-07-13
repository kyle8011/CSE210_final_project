using System;
using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Scripting;
using unit06_game.Game.Services;


namespace unit06_game.Game.Casting
{
    /// <summary>
    /// <para>Keeps track of how long the game has run</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Display : Actor
    {
        private int value = 0;
        private Cast cast;
        private string name = "";
        private VideoService videoService;
        private int damage = 1;
        private int range = 1;
        private int level = 1;
        private int poison = 1;
        private int critical = 1;
        private Random random= new Random();
        /// <summary>
        /// Constructs a new instance of Score, starting at 0.
        /// </summary>
        public Display(Cast cast, string name, VideoService videoService)
        {
            this.videoService = videoService;
            this.cast = cast;
            this.name = name;
            SetColor(new Color (200, 200, 0));
            if (name == "EndGame")
            {
                SetFontSize(100);
            }
        }

        /// <summary>
        /// Sets the name of the actor
        /// </summary>
        /// <param name="name">The name of the actor.</param>
        public void UpdateValue()
        {
            if (name == "wave" || name == "gold" || name == "lives") {
                SetText($"{name}: {GetValue()}");
            }
                        
            else if (name == "fire" || name == "critical" || name == "poison") 
            {
                SetText($"{name} \n \n \n {GetValue()}");
            }

            else if (name == "EndGame")
            {
                SetText($"Game Over");
                SetColor(new Color(random.Next(255), random.Next(65), random.Next(125)));
            }
        }
       
        public int GetValue() 
        {
            Stats stats = (Stats) cast.GetFirstActor("stats");
            List<Actor> fire_towers = cast.GetActors("fire_tower");
            List<Actor> crit_towers = cast.GetActors("crit_tower");
            List<Actor> poison_towers = cast.GetActors("poison_tower");
            if (name == "wave")
            {
                value = stats.GetWave();
            }
            else if (name == "gold")
            {
                value = stats.GetGold();
            }
            else if (name == "lives")
            {
                value = stats.GetLives();
            }
            else if (name == "poison") 
            {
                if (poison_towers != null) {
                    value = 100 + (poison_towers.Count * 100);
                }
                else {value = 100;}
            }
            else if (name == "fire") 
            {
                if (fire_towers != null) {
                    value = 100 + (fire_towers.Count * 100);
                }
                else {value = 100;}
            }
            else if (name == "critical") 
            {
                if (crit_towers != null) {
                    value = 100 + (crit_towers.Count * 100);
                }
                else {value = 0;}
            }
            else {value = 0;}
            return value;
        }

        public void ShowStats(Tower tower)
        {
            Display tower_stats = (Display)cast.GetFirstActor("tower_stats");
            Point position = tower.GetPosition();
            videoService.DrawRectangle(new Point (100, 120), new Point (1000, 0), new Color (50, 50, 50), true);
            tower_stats.damage = tower.GetDamage();
            tower_stats.range = tower.GetRange();
            tower_stats.level = tower.GetLevel();
            tower_stats.poison = tower.GetPoisonDamage();
            tower_stats.critical = tower.GetCritChance();
            if (tower.GetKind() == "fire") {
                tower_stats.SetText($" level: {tower_stats.level} \n damage: {tower_stats.damage} \n range: {tower_stats.range} \n upgrage: {tower.GetLevelPrice()}");
            }
            else if (tower.GetKind() == "poison") {
                tower_stats.SetText($" level: {tower_stats.level} \n damage: {tower_stats.damage} \n range: {tower_stats.range} \n poison: {tower_stats.poison} \n upgrade: {tower.GetLevelPrice()}");
            }
            else if (tower.GetKind() == "crit") {
                tower_stats.SetText($" level: {tower_stats.level} \n damage: {tower_stats.damage} \n range: {tower_stats.range} \n Critical: {tower_stats.critical} \n upgrade: {tower.GetLevelPrice()}");
            }
            videoService.DrawActor(tower_stats);
        }

    }
}