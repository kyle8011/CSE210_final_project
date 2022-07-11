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
// If the mouse is over the tower in menu then create a new tower and move it to a location
        public void Execute(Cast cast, Script script)
        {   Point position = mouseService.GetCoordinates();
            //it will pick a tower depending of the position
            int x = position.GetX();
            int y = position.GetY();
        
            //creating tower from menu
            if(Math.Abs(x-20)<40 & Math.Abs(y-20)<40)
            {
                cast.AddActor("poison_tower", new Tower(cast, "poison"));
            }
            else if(Math.Abs(x-140)<40& Math.Abs(y-20)<40)
            {
                cast.AddActor("fire_tower", new Tower(cast, "fire"));
                
            }
            else if(Math.Abs(x-80)<40& Math.Abs(y-80)<40)
            {
                cast.AddActor("crit_tower", new Tower(cast, "crit"));
            }

            //Picking the towers
            List<Actor> poison_towers = cast.GetActors("poison_tower");
            List<Actor> fire_towers = cast.GetActors("fire_tower");
            List<Actor> crit_towers = cast.GetActors("crit_tower");
            //----centering the mouse on the poison tower----
            foreach (Tower tower in poison_towers)
            {
                Point towerPosition = tower.GetPosition();
                int xTower = towerPosition.GetX();
                int yTower = towerPosition.GetY();
                x=x-20;
                y=y-20;
                bool hitbox =(Math.Abs(xTower-x)<40 && Math.Abs(yTower-y)<40);
                position = new Point(x,y);
                if (mouseService.IsButtonDown(Constants.MOUSE_PRESSED) && hitbox)
                {
                     tower.SetPosition(position);
                }
            }

           //----centering the mouse on the fire tower----
            foreach (Tower tower in fire_towers)
            {
                Point towerPosition = tower.GetPosition();
                int xTower = towerPosition.GetX();
                int yTower = towerPosition.GetY();
                x=x-20;
                y=y-20;
                bool hitbox =(Math.Abs(xTower-x)<40 && Math.Abs(yTower-y)<40);
                position = new Point(x,y);
                if (mouseService.IsButtonDown(Constants.MOUSE_PRESSED) && hitbox)
                {
                     tower.SetPosition(position);
                }
            }

           //----centering the mouse on the crit tower----
            foreach (Tower tower in crit_towers)
            {
                Point towerPosition = tower.GetPosition();
                int xTower = towerPosition.GetX();
                int yTower = towerPosition.GetY();
                x=x-20;
                y=y-20;
                bool hitbox =(Math.Abs(xTower-x)<40 && Math.Abs(yTower-y)<40);
                position = new Point(x,y);
                if (mouseService.IsButtonDown(Constants.MOUSE_PRESSED) && hitbox)
                {
                     tower.SetPosition(position);
                }
            }

        }
    }
}