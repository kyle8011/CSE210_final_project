using unit06_game.Game.Casting;
using System.Collections.Generic;

namespace unit06_game.Game.Scripting
{
    public class UpdateHudAction : Action
    {
        private int i = 0;
        public UpdateHudAction()
        {

        }

        public void Execute(Cast cast, Script script)
        {
            Display gold = (Display) cast.GetFirstActor("gold");
            gold.SetPosition(new Point(500, 0));
            gold.UpdateValue();

            Display wave = (Display) cast.GetFirstActor("wave");
            wave.SetPosition(new Point (400, 0));
            wave.UpdateValue();

            Display lives = (Display) cast.GetFirstActor("lives");
            lives.SetPosition(new Point (600, 0));
            lives.UpdateValue();

            List<Actor> shop = cast.GetActors("shop");
            Display poison = (Display) cast.GetFirstActor("shop");
            poison.UpdateValue();
            Display critical = (Display) cast.GetSecondActor("shop");
            critical.UpdateValue();
            Display fire = (Display) cast.GetThirdActor("shop");
            fire.UpdateValue();

            for (i = 0; i < shop.Count; i++) {
                shop[i].SetPosition(new Point (20 + (i * 60), 0));
            }

            Display tower_stats = (Display) cast.GetFirstActor("tower_stats");
            tower_stats.SetPosition(new Point (1000, 0));
        }
    }
}