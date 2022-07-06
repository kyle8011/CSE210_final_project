using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Services;
using System;

namespace unit06_game.Game.Scripting
{    /// <summary>
    /// <para>An update action that moves the tower using mouse service</para>
    /// <para>
    /// The responsibility of MoveTower is to move the tower when the mouse clicks a tower.
    /// </para>
    /// </summary>
    public class ControlTowerAction : Action
    {    private MouseService mouseService;

        public ControlTowerAction(MouseService mouseService)
        {
            this.mouseService = mouseService;
        }

        public void Execute(Cast cast, Script script)
        {
            Tower tower = (Tower)cast.GetFirstActor(Constants.TOWER_GROUP);

           //if (keyboardService.IsKeyDown(Constants.LEFT))
           //{
           //    racket.SwingLeft();
           //}
           //else if (keyboardService.IsKeyDown(Constants.RIGHT))
           //{
           //    racket.SwingRight();
           //}
           //else
           //{
           //    racket.StopMoving();
           //}
           Point position = mouseService.GetCoordinates();
           if (mouseService.IsButtonPressed(Constants.MOUSE_PRESSED))
           {
                tower.SetPosition(position);
           }

        }
    }
}