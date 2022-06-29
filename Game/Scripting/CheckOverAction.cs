using System.Collections.Generic;
using unit06_game.Casting;
using unit06_game.Services;


namespace unit06_game.Scripting
{
    public class CheckOverAction : Action
    {
        public CheckOverAction()
        {
        }

        public void Execute(Cast cast, Script script)
        {
            List<Actor> bricks = cast.GetActors(Constants.BRICK_GROUP);
            if (bricks.Count == 0)
            {
                Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
                stats.AddLevel();
                callback.OnNext(Constants.NEXT_LEVEL);
            }
        }
    }
}