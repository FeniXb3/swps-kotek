Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Point startingPoint = new Point(16, 2);
Player hero = new Player("Snake", "@");
hero.speed = 1;
hero.position = startingPoint;

List<Player> clones = new List<Player>();
clones.Add(hero);

string[] level =
[
    "####################################",
    "#..................................#",
    "#...........#........&......########",
    "#.....#....................#####",
    "#...............................#",
    "#....................#.....#####",
    "##..........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........#...............#",
    "#...........#...............#",
    "#...........#...............#",
    "#############################",
];

foreach (string row in level)
{
    Console.WriteLine(row);
}

while (true)
{
    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        Console.Write(element.avatar);
    }

    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    if (!directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        if (pressedKeyInfo.Key == ConsoleKey.C)
        {
            Player clone = new Player(hero.name, "C");
            clone.position = startingPoint;
            clones.Add(clone);
        }

        continue;
    }

    foreach (Player element in clones)
    {
        Console.SetCursorPosition(element.position.x, element.position.y);
        string row = level[element.position.y];
        char cellValue = row[element.position.x];
        Console.Write(cellValue);

        Point direction = directionsMap[pressedKeyInfo.Key];
        Point target = element.position;

        // target.x += direction.x * element.speed;
        // target.y += direction.y * element.speed;

        int signX = Math.Sign(direction.x);
        for (int x = 1; x <= Math.Abs(direction.x * element.speed); x++)
        {
            int coordinateToTest = element.position.x + x * signX;
            if (level[target.y][coordinateToTest] == '#')
            {
                break;
            }

            target.x = coordinateToTest;
        }

        int signY = Math.Sign(direction.y);
        for (int y = 1; y <= Math.Abs(direction.y * element.speed); y++)
        {
            int coordinateToTest = element.position.y + y * signY;
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
            element.position = target;
            element.speed += 1;
        }
    }
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);

