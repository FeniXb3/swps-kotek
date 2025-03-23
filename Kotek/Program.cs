Player hero = new Player("Snake");

Console.WriteLine($"({hero.x}, {hero.y})");

while (true)
{
    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
    if (pressedKeyInfo.Key == ConsoleKey.A)
    {
        hero.x -= 1;
    }
    if (pressedKeyInfo.Key == ConsoleKey.D)
    {
        hero.x += 1;
    }
    if (pressedKeyInfo.Key == ConsoleKey.W)
    {
        hero.y -= 1;
    }
    if (pressedKeyInfo.Key == ConsoleKey.S)
    {
        hero.y += 1;
    }

    Console.Clear();
    
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"({hero.x}, {hero.y})");

    Console.SetCursorPosition(hero.x, hero.y);
    Console.Write("@");
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);

