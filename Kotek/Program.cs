﻿Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Point startingPoint = new Point(1, 2);
Player hero = new Player("Snake", "@");
hero.speed = 1;
hero.position = startingPoint;

List<Player> clones = new List<Player>();
clones.Add(hero);

string[] level =
[
    "#############################",
    "#...........................#",
    "#....................&......#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
    "#...........................#",
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
        
        element.position.x += direction.x * element.speed;
        element.position.y += direction.y * element.speed;

        element.position.x = Math.Clamp(element.position.x, 0, level[0].Length - 1);
        element.position.y = Math.Clamp(element.position.y, 0, level.Length - 1);

        // element.speed += 1;
    }
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);

