Dictionary<ConsoleKey, Point> directionsMap = new Dictionary<ConsoleKey, Point>();
directionsMap.Add(ConsoleKey.A, new Point(-1, 0));
directionsMap.Add(ConsoleKey.D, new Point(1, 0));
directionsMap.Add(ConsoleKey.W, new Point(0, -1));
directionsMap.Add(ConsoleKey.S, new Point(0, 1));

Player hero = new Player("Snake");
hero.speed = 1;
hero.position = new Point(1, 2);

while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.position.x}, {hero.position.y})    ");

    Console.SetCursorPosition(hero.position.x, hero.position.y);
    Console.Write("@");

    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    if (!directionsMap.ContainsKey(pressedKeyInfo.Key))
    {
        continue;
    }

    Console.SetCursorPosition(hero.position.x, hero.position.y);
    Console.Write(" ");

    Point direction = directionsMap[pressedKeyInfo.Key];
    
    hero.position.x += direction.x * hero.speed;
    hero.position.y += direction.y * hero.speed;

    hero.position.x = Math.Clamp(hero.position.x, 0, Console.BufferWidth - 1);
    hero.position.y = Math.Clamp(hero.position.y, 0, Console.BufferHeight - 1);

    hero.speed += 1;
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);

