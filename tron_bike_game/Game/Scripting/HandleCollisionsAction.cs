using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool snake1_loses = false;
        private bool snake2_loses = false;
        private bool crash = false;
        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (snake1_loses == false && snake2_loses == false)
            {
                HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleFoodCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");

            Score score = (Score)cast.GetFirstActor("score");
            Food food = (Food)cast.GetFirstActor("food");
            
            int points = food.GetPoints();
            snake.GrowTail(points);
            snake2.GrowTail2(points);
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head = snake.GetHead();
            Actor head2 = snake2.GetHead2();
            List<Actor> body = snake.GetBody();
            List<Actor> body2 = snake2.GetBody2();

            foreach (Actor segment in body)
            {
                // If snake 1 (Yellow) runs into snake 2 (Green), snake 1 loses.
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    snake2_loses = true;
                }
                // If snake 1 (Yellow) runs into itself (Yellow), snake 1 loses.
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    snake1_loses = true;
                }
                // Snake 2 lose conditions (Bottom Snake).
                foreach (Actor segment2 in body2)
                {
                    // If the snakes crash, they both lose.
                    if (head.GetPosition().Equals(head2.GetPosition()))
                    {
                        crash = true;
                    }

                    // If snake 2 (Green) runs into snake 1 (Yellow), snake 2 loses.
                    if (segment2.GetPosition().Equals(head.GetPosition()))
                    {
                        snake1_loses = true;
                    }
                    // If snake 2 (Green) runs into itself (Green), snake 2 loses.
                    if (segment2.GetPosition().Equals(head2.GetPosition()))
                    {
                        snake2_loses = true;
                    }
                }
            }


        }





        private void HandleGameOver(Cast cast)
        {
            if (snake1_loses == true && crash == false)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");

                List<Actor> segments = snake.GetSegments();
                List<Actor> segments2 = snake2.GetSegments2();

                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Green Wins!"); //Snake 1 LOSES!
                message.SetColor(Constants.GREEN);
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make 
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }

                foreach (Actor segment2 in segments2)
                {
                    segment2.SetColor(Constants.GREEN);
                }
                food.SetColor(Constants.GREEN);
            }

            if (snake2_loses == true && crash == false)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");

                List<Actor> segments = snake.GetSegments();
                List<Actor> segments2 = snake2.GetSegments2();

                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Yellow Wins!"); //Snake 1 LOSES!
                message.SetColor(Constants.YELLOW);
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make 
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.YELLOW);
                }

                foreach (Actor segment2 in segments2)
                {
                    segment2.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.YELLOW);
            }

            if (crash == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");

                List<Actor> segments = snake.GetSegments();
                List<Actor> segments2 = snake2.GetSegments2();

                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("YOU CRASHED! YOU BOTH LOSE!"); //Snake 1 LOSES!
                message.SetColor(Constants.RED);
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make 
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }

                foreach (Actor segment2 in segments2)
                {
                    segment2.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
            }
        }

    }
}