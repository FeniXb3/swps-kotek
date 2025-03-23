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
        if (hero.x - hero.speed >= 0)
        {
            hero.x -= hero.speed;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.D)
    {
        if (hero.x + hero.speed <= Console.BufferWidth - 1)
        {
            hero.x += hero.speed;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.W)
    {
        if (hero.y - hero.speed >= 0)
        {
            hero.y -= hero.speed;
        }
    }
    if (pressedKeyInfo.Key == ConsoleKey.S)
    {
        if (hero.y + hero.speed <= Console.BufferHeight - 1)
        {
            hero.y += hero.speed;
        }
    }

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

