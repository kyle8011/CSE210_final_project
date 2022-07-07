using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;


namespace unit06_game.Game.Scripting
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
            List<Actor> towers = cast.GetActors("tower");
            List<Enemy> enemies = cast.GetEnemies("enemy");
            //Point Score1Position = new Point(0,0);
            //score1.SetPosition(Score1Position);
            //Point Score2Position = new Point(Constants.MAX_X-200,0);
            //score2.SetPosition(Score2Position);
            Actor gold = cast.GetFirstActor("gold");          
            Actor wave = cast.GetFirstActor("wave");
            Actor lives = cast.GetFirstActor("lives");
            
            videoService.ClearBuffer();
            videoService.DrawEnemies(enemies);
            foreach (Enemy enemy in enemies)
            {
                videoService.DrawRectangle(new Point (enemy.GetHealthBarLength(), 10), enemy.GetHealthBarPosition(), enemy.GetColor(), true);
            }
            foreach (Actor tower in towers) {
                videoService.DrawRectangle(new Point (40, 40), tower.GetPosition(), tower.GetColor(), true);
            }
            //videoService.DrawActors(towers);
            videoService.DrawActor(gold);
            videoService.DrawActor(wave);
            videoService.DrawActor(lives);
            // Draw the end zone
            videoService.DrawRectangle(new Point (100, 100), new Point (Constants.MAX_X - 100, Constants.MAX_Y / 2 - 50), new Color (0, 0, 200), true);
            
            videoService.FlushBuffer();
            videoService.ClearBuffer();
        }
    }
}