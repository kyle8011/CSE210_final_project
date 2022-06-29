using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class DrawSceneAction : Action
    {
        private VideoService videoService;
        
        public DrawSceneAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script)
        {
            Ball ball = (Scene)cast.GetFirstActor(Constants.BALL_GROUP);
            Body body = ball.GetBody();
            Image image = ball.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}