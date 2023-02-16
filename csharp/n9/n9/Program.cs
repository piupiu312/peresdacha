using System;
using System.Diagnostics;
using System.Linq;

namespace n9
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    class Program
    {
        static readonly int fieldWidth = 70;
        static readonly int fieldHeight = 30;
        private const int Frames = 150;

        static void Main()
        {

            Console.CursorVisible = false;
            while (true)
            {
                GameStart();
                Console.ReadKey();
            }
        }
        static void DrawBorder()
        {
            for (int i = 0; i < fieldWidth; i++)
            {
                new Pixelgran(x: i, y: 0).DrawX();
                new Pixelgran(x: i, y: fieldHeight - 1).DrawX();
            }
            for (int i = 0; i < fieldHeight; i++)
            {
                new Pixelgran(x: 0, y: i).DrawY();
                new Pixelgran(x: fieldWidth - 1, y: i).DrawY();
            }
        }

        static Pixelfood GetFood(SnakeItSelf snake)
        {
            Pixelfood food;

            do
            {
                food = new Pixelfood(new Random().Next(1, fieldWidth - 2), new Random().Next(1, fieldHeight - 2));
            }
            while (snake.Head.X == food.X && snake.Head.Y == food.Y || snake.Body.Any(i => i.X == snake.Head.X && i.Y == snake.Head.Y));

            return food;
        }


        static Direction Movement(Direction currrentDirection)
        {
            if (!Console.KeyAvailable) return currrentDirection;

            ConsoleKey key = Console.ReadKey(intercept: true).Key;

            currrentDirection = key switch
            {
                ConsoleKey.W when currrentDirection != Direction.Down => Direction.Up,
                ConsoleKey.S when currrentDirection != Direction.Up => Direction.Down,
                ConsoleKey.D when currrentDirection != Direction.Left => Direction.Right,
                ConsoleKey.A when currrentDirection != Direction.Right => Direction.Left,
                _ => currrentDirection
            };
            return currrentDirection;
        }
        static void GameStart()
        {
            Console.Clear();

            DrawBorder();

            Direction movement = Direction.Up;

            var snake = new SnakeItSelf(initialX: fieldWidth / 2, initialY: fieldHeight / 2);
            Stopwatch stw = new Stopwatch();
            int score = 0;

            Pixelfood food = GetFood(snake);
            food.Draw();

            while (true)
            {
                stw.Restart();

                Direction prevMovement = movement;
                while (stw.ElapsedMilliseconds <= Frames)
                {
                    if (movement == prevMovement)
                    {
                        movement = Movement(movement);
                    }

                }
                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(movement, eat: true);
                    food = GetFood(snake);
                    food.Draw();
                    score++;
                }
                else
                {
                    snake.Move(movement);
                }



                if (snake.Head.X == fieldWidth - 1
                    || snake.Head.X == 0
                    || snake.Head.Y == fieldHeight - 1
                    || snake.Head.Y == 0
                    || snake.Body.Any(i => i.X == snake.Head.X && i.Y == snake.Head.Y))

                    break;
            }

            snake.Clear();
            Console.SetCursorPosition(left: 15, top: 10);
            Console.WriteLine("GAME OVER");
            Console.SetCursorPosition(left: 14, top: 13);
            Console.WriteLine($"Счёт: {score}");

        }
      }
}
