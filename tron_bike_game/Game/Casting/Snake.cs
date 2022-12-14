using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Unit05.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Snake : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private List<Actor> segments2 = new List<Actor>();
        //Color Color:
        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>

        Color color;
        public Snake(Color color, Vector2 startingPosition)
        {
            this.color = color;
            PrepareBody(startingPosition);
            PrepareBody2(startingPosition);
            //this.Color = color;
        }
        

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        public List<Actor> GetBody2()
        {
            return new List<Actor>(segments2.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        public Actor GetHead2()
        {
            return segments2[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        public List<Actor> GetSegments2()
        {
            return segments2;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                segment.SetColor(this.color);
                segments.Add(segment);
            }
        }
        public void GrowTail2(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail2 = segments2.Last<Actor>();
                Point velocity = tail2.GetVelocity();
                Point offset = velocity.Reverse();
                Point position2 = tail2.GetPosition().Add(offset);

                Actor segment2 = new Actor();
                segment2.SetPosition(position2);
                segment2.SetVelocity(velocity);
                segment2.SetText("#");
                segment2.SetColor(this.color);
                segments2.Add(segment2);
            }
        }


        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }

        }

        public override void MoveNext2()
        {
            foreach (Actor segment2 in segments2)
            {
                segment2.MoveNext2();
            }

            for (int i = segments2.Count - 1; i > 0; i--)
            {
                Actor trailing2 = segments2[i];
                Actor previous2 = segments2[i - 1];
                Point velocity2 = previous2.GetVelocity();
                trailing2.SetVelocity(velocity2);
            }

        }


        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        public void TurnHead2(Point direction2)
        {
            segments2[0].SetVelocity(direction2);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody(Vector2 startingPosition)
        {
            int x = (int)startingPosition.X;
            int y = (int)startingPosition.Y;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = i == 0 ? this.color: this.color;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
            }
        }

        private void PrepareBody2(Vector2 startingPosition)
        {
            int x = (int)startingPosition.X;
            int y = (int)startingPosition.Y;

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position2 = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "8" : "#";
                Color color = i == 0 ? this.color: this.color;
                

                Actor segment2 = new Actor();
                segment2.SetPosition(position2);
                segment2.SetVelocity(velocity);
                segment2.SetText(text);
                segment2.SetColor(color);
                segments2.Add(segment2);
            }
        }
    }
}