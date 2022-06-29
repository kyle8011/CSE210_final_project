using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class ChangeSceneAction : Action
    {
        private KeyboardService keyboardService;
        private string nextScene;

        public ChangeSceneAction(KeyboardService keyboardService, string nextScene)
        {
            this.keyboardService = keyboardService;
            this.nextScene = nextScene;
        }

        public void Execute(Cast cast, Script script)
        {
            if (keyboardService.IsKeyPressed(Constants.ENTER))
            {
                callback.OnNext(nextScene);
            }
        }
    }
}