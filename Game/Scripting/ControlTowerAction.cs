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
            Point position = mouseService.GetCoordinates();
            //centering the mouse on the tower
            Point towerPosition = tower.GetPosition();
            int xTower = towerPosition.GetX();
            int yTower = towerPosition.GetY();
            int x = position.GetX() -20;
            int y = position.GetY()-20;
            
            bool hitbox =(Math.Abs(xTower-x)<40 && Math.Abs(yTower-y)<40);
            position = new Point(x,y);
           

           if (mouseService.IsButtonDown(Constants.MOUSE_PRESSED) && hitbox)
           {
                tower.SetPosition(position);
           }

        }
    }
}