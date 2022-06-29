using System.Collections.Generic;
using UNIT06_GAME.Casting;
using UNIT06_GAME.Services;


namespace UNIT06_GAME.Scripting
{
    public class DrawDialogAction : Action
    {
        private VideoService videoService;
        
        public DrawDialogAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> actors = cast.GetActors(Constants.DIALOG_GROUP);
            foreach (Actor actor in actors)
            {
                Label label = (Label)actor;
                Text text = label.GetText();
                Point position = label.GetPosition();
                videoService.DrawText(text, position);
            }
        }
    }
}