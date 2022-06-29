using System.Collections.Generic;
using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class DrawBricksAction : Action
    {
        private VideoService videoService;
        
        public DrawBricksAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> bricks = cast.GetActors(Constants.BRICK_GROUP);
            foreach (Actor actor in bricks)
            {
                Brick brick = (Brick)actor;
                Body body = brick.GetBody();

                if (brick.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = brick.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
        }
    }
}