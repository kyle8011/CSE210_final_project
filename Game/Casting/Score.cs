using System;
using System.Collections.Generic;


namespace unit06_game.Game.Casting
{
    /// <summary>
    /// <para>Keeps track of how long the game has run</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Time : Actor
    {
        private int time = 0;
        private string name = "";

        /// <summary>
        /// Constructs a new instance of Score, starting at 0.
        /// </summary>
        public Time(Cast cast)
        {
            AddTime(cast);
        }

        /// <summary>
        /// Increments time by 1 and sets the text
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddTime(Cast cast)
        {
            time++;
            SetText($"{this.name} {this.time}");
        }
        /// <summary>
        /// Sets the name of the actor
        /// </summary>
        /// <param name="SetName">The name of the actor.</param>
        public void SetName(string SetName)
        {
            this.name = SetName;
        }
       
        public int GetTime() 
        {
            return time;
        }

    }
}