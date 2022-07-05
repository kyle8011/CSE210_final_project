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
            SetText($"{name}: {GetValue()}");
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
            if (name == "wave")
            {
                value = stats.GetWave();
                SetText("wave");
            }
            else if (name == "gold")
            {
                value = stats.GetGold();
            }
            else if (name == "lives")
            {
                value = stats.GetLives();
            }
            else {value = 0;}
            return value;
        }

    }
}