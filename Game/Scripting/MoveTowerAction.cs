//using System.Collections.Generic;
//using unit06_game.Game.Casting;
//using unit06_game.Game.Services;
//
//namespace unit06_game.Game.Scripting
//{    /// <summary>
//    /// <para>An update action that moves the tower using mouse service</para>
//    /// <para>
//    /// The responsibility of MoveTower is to move the tower when the mouse clicks a tower.
//    /// </para>
//    /// </summary>
//    public class MoveTowerAction : Action
//    {   MouseService mouseService;
//
//        /// <summary>
//        /// Constructs a new instance of MoveActorsAction.
//        /// </summary>
//        public MoveTowerAction(MouseService mouseService)
//        {this.mouseService = mouseService;}
//
//        // 3) Override the Execute(Cast cast, Script script) method. Use the following 
//        //    method comment. Your custom implementation should do the following:
//        //    a) get all the actors from the cast
//        //    b) loop through all the actors
//        //    c) call the MoveNext() method on each actor.
//        public void Execute(Cast cast, Script script)
//        {
//            List<Tower> towers = cast.GetTower("tower");
//            foreach (Tower tower in towers)
//            {   
//                if(mouseService.IsButtonDown("left") && mouseService.GetCoordinates().GetX() <= tower.GetPosition().GetX() + 50 && mouseService.GetCoordinates().GetY() <= tower.GetPosition().GetY()))
//                {
//                    //moving the towers to the position of the mouse
//                    //enemy.MoveNext();
//                }
//                
//            }
//        }
//    }
//}