using Raylib_cs;
using UNIT06_GAME.Casting;
using UNIT06_GAME.Services;


namespace UNIT06_GAME.Scripting
{
    public class EndDrawingAction : Action
    {
        private VideoService videoService;
        
        public EndDrawingAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            videoService.FlushBuffer();
        }
    }
}