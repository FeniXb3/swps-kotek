Player hero = new Player("Snake");
hero.speed = 3;
hero.x = 1;
hero.y = 2;

Console.WriteLine($"({hero.x}, {hero.y})");

while (true)
{
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write(" ");

    if (pressedKeyInfo.Key == ConsoleKey.A)
    {
        hero.x -= hero.speed;
    }
    else if (pressedKeyInfo.Key == ConsoleKey.D)
    {
        hero.x += hero.speed;
    }
    else if (pressedKeyInfo.Key == ConsoleKey.W)
    {
        hero.y -= hero.speed;
    }
    else if (pressedKeyInfo.Key == ConsoleKey.S)
    {
        hero.y += hero.speed;
    }

    hero.x = Math.Clamp(hero.x, 0, Console.BufferWidth - 1);
    hero.y = Math.Clamp(hero.y, 0, Console.BufferHeight - 1);

    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})    ");

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);

