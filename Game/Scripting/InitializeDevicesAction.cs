using UNIT06_GAME.Casting;
using UNIT06_GAME.Services;


namespace UNIT06_GAME.Scripting
{
    public class InitializeDevicesAction : Action
    {
        private AudioService audioService;
        private VideoService videoService;
        
        public InitializeDevicesAction(AudioService audioService, VideoService videoService)
        {
            this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            audioService.Initialize();
            videoService.Initialize();
        }
    }
}