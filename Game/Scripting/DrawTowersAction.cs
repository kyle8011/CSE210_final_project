using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class DrawEnemyAction : Action
    {
        private VideoService videoService;
        
        public DrawEnemyAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script)
        {
        //    Racket racket = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
        //    Body body = racket.GetBody();
//
        //    if (racket.IsDebug())
        //    {
        //        Rectangle rectangle = body.GetRectangle();
        //        Point size = rectangle.GetSize();
        //        Point pos = rectangle.GetPosition();
        //        videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
        //    }
//
        //    Animation animation = racket.GetAnimation();
        //    Image image = animation.NextImage();
        //    Point position = body.GetPosition();
        //    videoService.DrawImage(image, position);
        }
    }
}