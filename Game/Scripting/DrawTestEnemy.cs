using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System;


namespace unit06_game.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws a test enemy.</para>
    /// </summary>
    public class DrawTestEnemy : Action
    {
        private VideoService videoService;
        private TestEnemy enemy;
        private Path path;

        /// <summary>
        /// Constructs a new instance of Drawenemy.
        /// </summary>
        public DrawTestEnemy(VideoService videoService,TestEnemy enemy, Path path)
        {
            this.videoService = videoService;
            this.enemy = enemy;
            this.path = path;
        }
        
        //method  for moving the test enemy.
        //it can be done in another class called move enemy, but I am lazy u.u
        //Doing this gave me the idea that the path should carry the velocities
        //since the path knows where are going to be the turns.
        public void MoveTestEnemy(Path path)
        {   List<Point> points = path.GetPath();
            Point FirstPoint = points[0];
            enemy.SetPosition(FirstPoint);
            enemy.MoveNext();
        }
        //another method is required for removing the test enemy of the screen
        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {   //drawing the enemy
            videoService.ClearBuffer();
            videoService.DrawTestEnemy(enemy);
            MoveTestEnemy(path);
            videoService.FlushBuffer();
            videoService.ClearBuffer();
        }
    }
}