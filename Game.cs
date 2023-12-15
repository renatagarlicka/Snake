
namespace Snake;


internal class Game
{
    public System.Timers.Timer timer;

    private readonly Random random;
    private Snake snake;
    private int foodPositionX;
    private int foodPositionY;
    private bool gameOver = false;
    private int positionBoardX1 = 0;
    private int positionBoardX2 = 21;
    private int positionBoardY1 = 0;
    private int positionBoardY2 = 21;
    private int score = 0;
    Menu menu = new Menu();

    public Game()
    {
        timer = new System.Timers.Timer();
        timer.Elapsed += Timer_Elapsed;
        timer.Interval = 200;

        random = new Random(DateTime.Now.Millisecond);

        snake = new Snake(5, 5);
        snake.SetDirection(Direction.Right);
    }

    private void GenerateFoodPosition()
    {
        foodPositionX = random.Next(20);
        foodPositionY = random.Next(20);

        Console.SetCursorPosition(foodPositionX, foodPositionY);
        Console.Write("a");
    }

    private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        
        snake.Move();
        CleanCurrentSnakePosition();
        TryEatFood();
        DrawSnake();
    }

    private void AddScore()
    {
        score += 5;
    }

    private void TryEatFood()
    {
        if (foodPositionX == snake.SnakeHead.PositionX && foodPositionY == snake.SnakeHead.PositionY)
        {
            snake.Grow();
            AddScore();
            GenerateFoodPosition();
        }
    }

    private void CleanCurrentSnakePosition()
    {
        Console.SetCursorPosition(snake.SnakeTail.PositionX, snake.SnakeTail.PositionY);
        Console.Write(' ');
    }

    public void Play()
    {
        while (gameOver == false)
        {
            snake.MakeSnake(5,5);
            timer.Start();
            GenerateFoodPosition();
            snake = new Snake(5, 5);
        snake.SetDirection(Direction.Right);

            while (true)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        snake.SetDirection(Direction.Down);
                        break;
                    case ConsoleKey.UpArrow:
                        snake.SetDirection(Direction.Up);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.SetDirection(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.SetDirection(Direction.Right);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

    

    private void MakeEndingText()
    {
        Console.Clear();
        //snake.RemoveSnake();
        Console.WriteLine("Koniec gry");
        Console.WriteLine($"Twój wynik to: {score}");
        gameOver = false;
       
        menu.WywolajMenu();
        

    }

    public void EndGame()
    {
        if (gameOver)
        {
            timer.Stop();
         
            MakeEndingText();
        }
    
    }

    public void DrawSnake()
    {
        foreach (var segment in snake.SnakeSegments)
        {
            if (segment.PositionX == positionBoardX1 || segment.PositionX == positionBoardX2 || segment.PositionY == positionBoardY1 || segment.PositionY == positionBoardY2)
            {
                gameOver = true;
                EndGame();
            }
            Console.SetCursorPosition(segment.PositionX, segment.PositionY);
            Console.Write('O');
        }

    }
}
