using System;
using unit06_game.Game.Casting;
using unit06_game.Game.Scripting;
using Raylib_cs;
//Don't fotget to delete unnecesary libraries
namespace unit06_game.Game.Casting
{
    /// <summary>
    /// <para>A test enemy for testing movement.</para>
    /// <para>
    /// For the future, it will test change is stats, animations, etc.
    /// </para>
    /// <para>
    /// The idea is to put all of the successful test into the real enemy class. 
    /// </para>
    /// <para>
    /// Also, it purpose is to avoid overwriting on the code of someone more else.
    /// </para>
    /// </summary>
     public class TestEnemy : Actor
     {
        private int health = 300;
        private Color color = Constants.YELLOW; //the color is constant now, but later this has to be changed

//since each enemy should be different, the will have a different speed, health, and shape
//the shape and health will be tested later.
//for this test, the test enemy should follow the given path and die at the end.
         public TestEnemy(){}

        // get position and velocity are heritated from the actor class
        
        /// <summary>
        /// Gets the health of the test enemy.
        /// </summary>
        public int GetHealth()
        {return this.health;}

     }
}