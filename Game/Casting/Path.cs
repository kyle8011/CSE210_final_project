using System;
using unit06_game.Game.Scripting;
using System.Collections.Generic;
using unit06_game.Game;
using System.Linq;

namespace unit06_game.Game.Casting
{
    /// <summary>
    /// <para>A set of points that together makes a path</para>
    /// <para>It is responsible for the direction of the movements of the enemies</para>
    /// </summary>
    public class Path : Actor
    {
        private List<Point> Points = new List<Point>();

        /// <summary>
        /// Constructs a new instance of a path.
        /// </summary>
        public Path(){}

        /// <summary>
        /// Gets the points of the path
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Point> GetPath()
        {
            return this.Points;
        }
     
        /// <summary>
        /// Makes a path, the instruction for each path should change with a level.
        /// In the future we are going to add more complexity in the paths.
        /// Right now it is a straight horizontal path.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void MakePath()
        {   int variable_x = 0;
            int constant_y = Constants.MAX_Y/2 - 10;

            for(int i=0; i < Constants.MAX_X; i = i + 100)
            {
                Point point = new Point(variable_x+i,constant_y);       //I make a bunch of points, and those points are added to the path
                this.Points.Add(point);                                 //for the future each level is a script that makes a path 
            }
        }
    }
}