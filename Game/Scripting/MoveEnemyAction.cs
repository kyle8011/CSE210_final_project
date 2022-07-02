using unit06_game.Casting;
namespace unit06_game.Scripting
{
    public class MoveEnemyAction : Action
    {
        public MoveEnemyAction()
        {
        }

        public void Execute(Cast cast, Script script)
        {
            Enemy enemy = (Enemy)cast.GetFirstActor(Constants.ENEMY_GROUP);
            Point position = enemy.GetPosition();
            Point velocity = enemy.GetVelocity();
            position = position.Add(velocity);
            enemy.SetPosition(position);
        }
    }
}