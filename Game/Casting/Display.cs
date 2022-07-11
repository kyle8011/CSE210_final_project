using System;
using System.Collections.Generic;
using unit06_game.Game.Casting;


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


        /// <summary>
        /// Constructs a new instance of Score, starting at 0.
        /// </summary>
        public Display(Cast cast, string name)
        {
            this.cast = cast;
            this.name = name;
            if (name == "wave" || name == "gold" || name == "lives") {
                SetText($"{name}: {GetValue()}");
            }
            else {SetText($"{name} \n \n \n {GetValue()}");}
            
            SetColor(new Color (200, 200, 0));
        }

        /// <summary>
        /// Sets the name of the actor
        /// </summary>
        /// <param name="name">The name of the actor.</param>
        public void UpdateValue()
        {
            SetText($"{name}: {GetValue()}");
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
                value = poison_towers.Count * 100;
            }
            else if (name == "fire") 
            {
                value = fire_towers.Count * 100;
            }
            else if (name == "critical") 
            {
                value = crit_towers.Count * 100;
            }
            else {value = 0;}
            return value;
        }

    }
}