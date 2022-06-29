using UNIT06_GAME.Casting;
namespace UNIT06_GAME.Scripting
{
    public class MoveBallAction : Action
    {
        public MoveBallAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Ball ball = (Ball)cast.GetFirstActor(Constants.BALL_GROUP);
            Body body = ball.GetBody();
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            position = position.Add(velocity);
            body.SetPosition(position);
        }
    }
}