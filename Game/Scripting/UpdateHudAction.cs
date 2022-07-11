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
            for (i = 0; i < shop.Count; i++) {
                shop[i].SetPosition(new Point (20 + (i * 60), 0));
            }
        }
    }
}