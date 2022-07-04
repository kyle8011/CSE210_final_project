using unit06_game.Game.Casting;

namespace unit06_game.Game.Scripting
{
    public class UpdateHudAction : Action
    {
        public UpdateHudAction()
        {

        }

        public void Execute(Cast cast, Script script)
        {
            Display gold = (Display) cast.GetFirstActor("gold");
            gold.SetPosition(new Point(400, 0));
            gold.UpdateValue("gold");

            Display wave = (Display) cast.GetFirstActor("wave");
            wave.SetPosition(new Point (300, 0));
            wave.UpdateValue("wave");

            Display lives = (Display) cast.GetFirstActor("lives");
            wave.SetPosition(new Point (500, 0));
            wave.UpdateValue("lives");
        }
    }
}