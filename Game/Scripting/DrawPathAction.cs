using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System;


namespace unit06_game.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the points in the path.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the points.</para>
    /// </summary>
    public class DrawPathAction : Action
    {
        private VideoService videoService;
        private Path path;
        private Color PathColor = new Color(0,0,0) ;

        /// <summary>
        /// Constructs a new instance of DrawPath using VideoService and a Path.
        /// </summary>
        public DrawPathAction(VideoService videoService, Path path)
        {
            this.videoService = videoService;
            this.path = path;
        }
        

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {   //drawing the path; if we want to make animations, that can be done in here.
            //videoService.DrawPath(path);
            List<Point> points = path.GetPath();
            foreach (Point position in points){
                Point size = new Point(100, 30);
                Color color = new Color(200, 200, 200);
                videoService.DrawRectangle(size, position, color, true);
            }
            
        }
    }
}