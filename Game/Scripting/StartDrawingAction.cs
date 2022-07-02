using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class StartDrawingAction : Action
    {
        private VideoService videoService;
        
        public StartDrawingAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script)
        {
            videoService.ClearBuffer();
        }
    }
}