using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class LoadAssetsAction : Action
    {
        
        private VideoService videoService;
        
        public LoadAssetsAction( VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script)
        {
            videoService.LoadFonts("Assets/Fonts");
            videoService.LoadImages("Assets/Images");
        }
    }
}