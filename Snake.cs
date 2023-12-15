namespace Snake;

internal class Snake
{
    private Queue<SnakeSegment> snakeSegments = new Queue<SnakeSegment>();
    private Direction movingDirection;

    public Snake(int startingPositionX, int startingPostionY)
    {
        var newSeqment = new SnakeSegment(startingPositionX, startingPostionY);
        snakeSegments.Enqueue(newSeqment);
    }

    public void MakeSnake(int startingPositionX, int startingPostionY)
    {
        var newSeqment = new SnakeSegment(startingPositionX, startingPostionY);
        snakeSegments.Enqueue(newSeqment);
    }

    public SnakeSegment SnakeHead
    {
        get
        {
            return snakeSegments.Last();
        }
    }

    public void RemoveSnake()
    {
        snakeSegments.Clear();
    }

    public SnakeSegment SnakeTail
    {
        get
        {
            return snakeSegments.Peek();
        }
    }

    public IEnumerable<SnakeSegment> SnakeSegments
    {
        get
        {
            return snakeSegments;
        }
    }

    public void SetDirection(Direction direction)
    {
        movingDirection = direction;
    }

    public void Grow()
    {
        AddSnakeSegmentOnDirection();
    }

    public void Move()
    {
        AddSnakeSegmentOnDirection();
        RemoveSnakeTail();
    }

    private void RemoveSnakeTail()
    {
        snakeSegments.Dequeue();
    }

    private void AddSnakeSegmentOnDirection()
    {
        var newSeqment = new SnakeSegment(SnakeHead.PositionX, SnakeHead.PositionY);
        switch (movingDirection)
        {
            case Direction.Left:
                newSeqment.PositionX -= 1;
                break;
            case Direction.Right:
                newSeqment.PositionX += 1;
                break;
            case Direction.Up:
                newSeqment.PositionY -= 1;
                break;
            case Direction.Down:
                newSeqment.PositionY += 1;
                break;
        }
        snakeSegments.Enqueue(newSeqment);
    }
}
