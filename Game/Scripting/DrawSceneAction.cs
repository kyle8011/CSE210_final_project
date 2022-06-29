using UNIT06_GAME.Casting;
using UNIT06_GAME.Services;


namespace UNIT06_GAME.Scripting
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
            Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            Body body = ball.GetBody();

            if (ball.IsDebug())
            {
                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
            }

            Image image = ball.GetImage();
            Point position = body.GetPosition();
            videoService.DrawImage(image, position);
        }
    }
}