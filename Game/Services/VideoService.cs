using System.Collections.Generic;
using System.Reflection.Metadata;
using Raylib_cs;
using unit06_game.Game.Casting;


namespace unit06_game.Game.Services
{
    /// <summary>
    /// <para>Outputs the game state.</para>
    /// <para>
    /// The responsibility of the class of objects is to draw the game state on the screen. 
    /// </para>
    /// </summary>
    public class VideoService
    {
        private Dictionary<string, Raylib_cs.Texture2D> textures
            = new Dictionary<string, Raylib_cs.Texture2D>();
        private bool debug = false;

        /// <summary>
        /// Constructs a new instance of KeyboardService using the given cell size.
        /// </summary>
        /// <param name="cellSize">The cell size (in pixels).</param>
        public VideoService(bool debug)
        {
            this.debug = debug;
        }

        /// <summary>
        /// Closes the window and releases all resources.
        /// </summary>
        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Clears the buffer in preparation for the next rendering. This method should be called at
        /// the beginning of the game's output phase.
        /// </summary>
        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.PURPLE);
            if (debug)
            {
                DrawGrid();
            }
        }

        /// <summary>
        /// Draws the given actor's text on the screen.
        /// </summary>
        /// <param name="actor">The actor to draw.</param>
        public void DrawActor(Actor actor)
        {
            string text = actor.GetText();
            int x = actor.GetPosition().GetX();
            int y = actor.GetPosition().GetY();
            int fontSize = actor.GetFontSize();
            Casting.Color c = actor.GetColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }

        public void DrawEnemy(Enemy actor)
        {
            string text = actor.GetText();
            int x = actor.GetPosition().GetX();
            int y = actor.GetPosition().GetY();
            int fontSize = actor.GetFontSize();
            Casting.Color c = actor.GetColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }        
        /// <summary>
        /// Draws a rectangle in a point given the width, height, position, color, and if it is filled or not.
        /// </summary>
        /// <param name="size">Point: info for width in x, and height in y</param>
        /// <param name="position">Point: info for the position of the rectangle</param>
        /// <param name="color">Color: A color class that sets the color of the rectangle in rgb (#red,#green,#blue)</param>
        /// <param name="filled">Bool: wether or not the rectangle is filled</param>
        public void DrawRectangle(Casting.Point size, Casting.Point position, Casting.Color color, bool filled)
        {
            int x = position.GetX();
            int y = position.GetY();
            int width = size.GetX();
            int height = size.GetY();
            Raylib_cs.Color raylibColor = ToRaylibColor(color);
            if (filled)
            {
                Raylib.DrawRectangle(x, y, width, height, raylibColor);
            }
            else
            {
                Raylib.DrawRectangleLines(x, y, width, height, raylibColor);
            }
        }


        /// <summary>
        /// Draws the given list of actors on the screen.
        /// </summary>
        /// <param name="actors">The list of actors to draw.</param>
        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }
         /// <summary>
        /// Draws a test enemy. For this test they will be yellow rectangles.
        /// </summary>
        /// <param name="enemy">The test enemy to be drawn</param>
        public void DrawTestEnemy(TestEnemy enemy)
        {
            Point position = enemy.GetPosition();
            Casting.Color color = enemy.GetColor();
            int size = Constants.CELL_SIZE;//the shape and size will be handle later
            int x = size;  //for now the test enemies will be rectangles
            int y = 2*size;
            Point PointSize = new Point(x,y);
            DrawRectangle(PointSize,position,color,true);
        }

        public void DrawEnemies(List<Enemy> actors)
        {
            foreach (Enemy actor in actors)
            {
                DrawEnemy(actor);
            }
        }
        ///</inheritdoc>
        //public void DrawImage(Casting.Photo image, Point position)
        //{
        //    string filename = image.GetFilename();
        //    if (!textures.ContainsKey(filename))
        //    {
        //        Raylib_cs.Texture2D loaded = Raylib.LoadTexture(filename);
        //        textures[filename] = loaded;
        //    }
        //    Raylib_cs.Texture2D texture = textures[filename];
        //    int x = position.GetX();
        //    int y = position.GetY();
        //    Raylib.DrawTexture(texture, x, y, Raylib_cs.Color.WHITE);
        //}
        
        /// <summary>
        /// Copies the buffer contents to the screen. This method should be called at the end of
        /// the game's output phase.
        /// </summary>
        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Whether or not the window is still open.
        /// </summary>
        /// <returns>True if the window is open; false if otherwise.</returns>
        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        /// <summary>
        /// Opens a new window with the provided title.
        /// </summary>
        public void OpenWindow()
        {
            Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.CAPTION);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        /// <summary>
        /// Draws a grid on the screen.
        /// </summary>
        private void DrawGrid()
        {
            for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, Constants.MAX_X, y, Raylib_cs.Color.GRAY);
            }
        }

        /// <summary>
        /// Converts the given color to it's Raylib equivalent.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>A Raylib color.</returns>
        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            int r = color.GetRed();
            int g = color.GetGreen();
            int b = color.GetBlue();
            int a = color.GetAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }
        public void DrawMenu()
        {   Point size = new Point(200,80);
            Point position = new Point(0,0);
            Casting.Color color = new Casting.Color(250,250,250);
            DrawRectangle(size,position,color,true);

            Point tower_size = new Point(40, 40);
            Point poison_tower_position = new Point(20, 20);        //towers position 
            Point crit_tower_position = new Point(80, 20);          //towers position
            Point fire_tower_position = new Point(140, 20);         //towers position
            Casting.Color poison_tower_color = new Casting.Color(0, 200, 0);
            Casting.Color crit_tower_color = new Casting.Color(0, 0, 200);
            Casting.Color fire_tower_color = new Casting.Color(200, 0, 0);
            DrawRectangle(tower_size, poison_tower_position, poison_tower_color, true);
            DrawRectangle(tower_size, crit_tower_position, crit_tower_color, true);
            DrawRectangle(tower_size, fire_tower_position, fire_tower_color, true);
        }

    }
}