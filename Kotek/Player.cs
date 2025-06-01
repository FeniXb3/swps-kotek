class Player
{
    public string name;
    public Point position;
    public int speed = 1;
    public string avatar;

    public Player(string name, string avatar)
    {
        this.name = name;
        this.avatar = avatar;
    }

    public void Move(Point direction, string[] level)
    {
        Point target = position;

        // target.x += direction.x * element.speed;
        // target.y += direction.y * element.speed;

        int signX = Math.Sign(direction.x);
        for (int x = 1; x <= Math.Abs(direction.x * speed); x++)
        {
            int coordinateToTest = position.x + x * signX;
            if (level[target.y][coordinateToTest] == '#')
            {
                break;
            }

            target.x = coordinateToTest;
        }

        int signY = Math.Sign(direction.y);
        for (int y = 1; y <= Math.Abs(direction.y * speed); y++)
        {
            int coordinateToTest = position.y + y * signY;
            if (level[coordinateToTest][target.x] == '#')
            {
                break;
            }

            target.y = coordinateToTest;
        }

        // HACK: We have to limit y before limiting x because we need row's lenght to limit x
        target.y = Math.Clamp(target.y, 0, level.Length - 1);
        target.x = Math.Clamp(target.x, 0, level[target.y].Length - 1);

        if (level[target.y][target.x] != '#')
        {
            position = target;
            speed += 1;
        }
    }

    public void Display()
    {
        Console.SetCursorPosition(position.x, position.y);
        Console.Write(avatar);
    }
}

/*
Klasa Player:
 - dane:
    - hp
    - maxHp
    - attackStrength
    - stamina
    - maxStamina
    - name
    - position
    - inventory
 - akcje:
    - attack
    - heal
    - move
    - pickUpItem
    - useItem
*/