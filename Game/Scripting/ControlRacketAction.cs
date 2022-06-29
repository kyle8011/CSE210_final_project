using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class ControlRacketAction : Action
    {
        private KeyboardService keyboardService;
        private AudioService audioService;

        public ControlRacketAction(KeyboardService keyboardService, AudioService audioService)
        {
            this.keyboardService = keyboardService;
            this.audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Sound bounceSound = new Sound(Constants.BOUNCE_SOUND);
            Racket racket = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                audioService.PlaySound(bounceSound);
                racket.SwingLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                racket.SwingRight();
            }
            else
            {
                racket.StopMoving();
            }
        }
    }
}