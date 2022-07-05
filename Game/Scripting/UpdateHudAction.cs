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
            gold.SetPosition(new Point(500, 0));
            gold.UpdateValue();

            Display wave = (Display) cast.GetFirstActor("wave");
            wave.SetPosition(new Point (400, 0));
            wave.UpdateValue();

            Display lives = (Display) cast.GetFirstActor("lives");
            lives.SetPosition(new Point (600, 0));
            lives.UpdateValue();
        }
    }
}