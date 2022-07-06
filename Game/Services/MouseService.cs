using System.Collections.Generic;
using Raylib_cs;
using unit06_game.Game.Casting;


namespace unit06_game.Game.Services
{
    public class MouseService
    {
        private Dictionary<string, Raylib_cs.MouseButton> buttons
                = new Dictionary<string, Raylib_cs.MouseButton>() {
            { "left", Raylib_cs.MouseButton.MOUSE_LEFT_BUTTON },
            { "middle", Raylib_cs.MouseButton.MOUSE_MIDDLE_BUTTON },
            { "right", Raylib_cs.MouseButton.MOUSE_RIGHT_BUTTON }
        };
        public MouseService(){}

        /// <summary>
        /// Get the current coordinate of the mouse
        /// </summary>
        /// <returns>Point with the coords of the mouse</returns>
        public Point GetCoordinates()
        {
            int x = Raylib.GetMouseX();
            int y = Raylib.GetMouseY();
            return new Point(x, y);
        }

    
        /// <summary>
        /// Checks if the left button of the mouse is hold.
        /// </summary>
        /// <param name="key">The given mouse button</param>
        /// <returns>True if the left button is pressed, false if otherwise.</returns>
        public bool IsButtonDown(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonDown(raylibButton);
        }

        /// <summary>
        /// Checks if the given click is the left button of the mouse
        /// </summary>
        /// <param name="key">The given mouse button</param>
        /// <returns>True if the given button is right, false if otherwise.</returns>
        public bool IsButtonPressed(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonPressed(raylibButton);
        }

        /// </inheritdoc>
        public bool IsButtonReleased(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonReleased(raylibButton);
        }

        /// </inheritdoc>
        public bool IsButtonUp(string button)
        {
            Raylib_cs.MouseButton raylibButton = buttons[button.ToLower()];
            return Raylib.IsMouseButtonUp(raylibButton);
        }
    }
}