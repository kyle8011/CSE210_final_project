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
            List<Actor> fire_towers = cast.GetActors("fire_tower");
            List<Actor> crit_towers = cast.GetActors("crit_tower");
            List<Actor> poison_towers = cast.GetActors("poison_tower");
            List<Enemy> enemies = cast.GetEnemies("enemy");
            Actor gold = cast.GetFirstActor("gold");
            Actor wave = cast.GetFirstActor("wave");
            Actor lives = cast.GetFirstActor("lives");
            
            List<Actor> shops = cast.GetActors("shop");
            
            videoService.ClearBuffer();
            videoService.DrawEnemies(enemies);
            foreach (Enemy enemy in enemies)
            {
                videoService.DrawRectangle(new Point (enemy.GetHealthBarLength(), 10), enemy.GetHealthBarPosition(), enemy.GetColor(), true);
            }
            foreach (Actor tower in fire_towers) {
                videoService.DrawRectangle(new Point (40, 40), tower.GetPosition(), tower.GetColor(), true);
            }
            foreach (Actor tower in crit_towers) {
                videoService.DrawRectangle(new Point (40, 40), tower.GetPosition(), tower.GetColor(), true);
            }
            foreach (Actor tower in poison_towers) {
                videoService.DrawRectangle(new Point (40, 40), tower.GetPosition(), tower.GetColor(), true);
            }
            //Draw Menu
                videoService.DrawMenu();
            foreach (Actor shop in shops) {
                videoService.DrawActor(shop);
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