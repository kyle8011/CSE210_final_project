using System.Collections.Generic;
using unit05_cycle_Team.Game.Casting;
using unit05_cycle_Team.Game.Services;


namespace unit05_cycle_Team.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake1 = (Snake) cast.GetFirstActor("snake");
            List<Actor> segments1 = snake1.GetSegments();
            Snake snake2 = (Snake) cast.GetSecondActor("snake");
            List<Actor> segments2 = snake2.GetSegments();
            Actor score1 = cast.GetFirstActor("score1");
            Actor score2 = cast.GetFirstActor("score2");
            Point Score1Position = new Point(0,0);
            score1.SetPosition(Score1Position);
            Point Score2Position = new Point(Constants.MAX_X-200,0);
            score2.SetPosition(Score2Position);
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments1);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score1);
            videoService.DrawActor(score2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}