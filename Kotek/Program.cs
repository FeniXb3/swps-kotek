Player hero = new Player("Snake");
hero.speed = 3;
hero.x = 1;
hero.y = 2;

while (true)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})    ");

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");

    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");

    Point direction;
    switch (pressedKeyInfo.Key)
    {
        case ConsoleKey.A:
            direction = new Point(-hero.speed, 0);
            break;
        case ConsoleKey.D:
            direction = new Point(hero.speed, 0);
            break;
        case ConsoleKey.W:
            direction = new Point(0, -hero.speed);
            break;
        case ConsoleKey.S:
            direction = new Point(0, hero.speed);
            break;
        default:
            direction = new Point(0, 0);
            break;
    }
    
    hero.x += direction.x;
    hero.y += direction.y;

    hero.x = Math.Clamp(hero.x, 0, Console.BufferWidth - 1);
    hero.y = Math.Clamp(hero.y, 0, Console.BufferHeight - 1);
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);

