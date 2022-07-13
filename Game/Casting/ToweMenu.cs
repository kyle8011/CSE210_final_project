using System.Collections.Generic;
using unit06_game.Game.Casting;
using unit06_game.Game.Scripting;
using System;
using Raylib_cs;
using unit06_game.Game.Services;

namespace unit06_game.Game.Casting
{
    public class Menu : Actor
    {
        MouseService mouseService;
        /// <summary>
        /// Creates an instance of a menu.
        /// </summary>
        public Menu(MouseService mouseService){this.mouseService = mouseService;}

        
        
    }
}