abstract class Character
{
    public string name;
    public Point Position { get; private set;}
    public int speed = 1;
    public string avatar;
    private readonly Level level;

    public Character(string name, string avatar, Point startingPoint, Level level)
    {
        this.name = name;
        this.avatar = avatar;
        this.Position = startingPoint;
        this.level = level;
        this.level.OccupyCell(Position, this);
    }

    public void Move(Point direction, Level level)
    {
        Point target = Position;

        int signX = Math.Sign(direction.x);
        for (int x = 1; x <= Math.Abs(direction.x * speed); x++)
        {
            int coordinateToTest = Position.x + x * signX;
            if (level.GetCellVisuals(coordinateToTest, target.y) == '#')
            {
                break;
            }

            target.x = coordinateToTest;
        }

        int signY = Math.Sign(direction.y);
        for (int y = 1; y <= Math.Abs(direction.y * speed); y++)
        {
            int coordinateToTest = Position.y + y * signY;
            if (level.GetCellVisuals(target.x, coordinateToTest) == '#')
            {
                break;
            }

            target.y = coordinateToTest;
        }

        // HACK: We have to limit y before limiting x because we need row's lenght to limit x
        target.y = Math.Clamp(target.y, 0, level.GetHeight() - 1);
        target.x = Math.Clamp(target.x, 0, level.GetRowWidth(target.y) - 1);

        if (level.GetCellVisuals(target.x, target.y) != '#')
        {
            Position = target;
            speed += 1;
        }
    }

    public void Display()
    {
        Console.SetCursorPosition(Position.x, Position.y);
        Console.Write(avatar);
    }

    public abstract string ChooseAction();
}
