using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class ReleaseDevicesAction : Action
    {
        private AudioService audioService;
        private VideoService videoService;
        
        public ReleaseDevicesAction(AudioService audioService, VideoService videoService)
        {
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            audioService.Release();
            videoService.Release();
        }
    }
}