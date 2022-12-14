using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);

        /// <sumdmary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left player 1
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }
            // left player 2
            if (keyboardService.IsKeyDown("key_left"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right player 1
            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }
            // right player 2
            if (keyboardService.IsKeyDown("key_right"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }
            // up player 1
            if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }
            // up player 2
            if (keyboardService.IsKeyDown("key_up"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down player 1
            if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }
            // down player 2
            if (keyboardService.IsKeyDown("key_down"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }



            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            snake.TurnHead(direction);
            snake2.TurnHead2(direction2);

        }
    }
}