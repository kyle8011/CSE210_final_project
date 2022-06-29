using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class DrawBallAction : Action
    {
        private VideoService videoService;
        
        public DrawSceneAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Scene)cast.GetFirstActor(Constants.BALL_GROUP);
            Body body = ball.GetBody();
            Image image = ball.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}