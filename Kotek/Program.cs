Dictionary<ConsoleKey, string> keyActionsMap = new Dictionary<ConsoleKey, string>();
keyActionsMap.Add(ConsoleKey.A, "moveLeft");
keyActionsMap.Add(ConsoleKey.D, "moveRight");
keyActionsMap.Add(ConsoleKey.W, "moveUp");
keyActionsMap.Add(ConsoleKey.S, "moveDown");
keyActionsMap.Add(ConsoleKey.C, "clone");

Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

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
        element.Display();
    }

    ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
    string chosenAction = keyActionsMap.GetValueOrDefault(pressedKeyInfo.Key, "pass");

    if (!directionsMap.ContainsKey(chosenAction))
    {
        if (chosenAction == "clone")
        {
            Player clone = new Player(hero.name, "C");
            clone.position = startingPoint;
            clones.Add(clone);
        }

        continue;
    }

    foreach (Player element in clones)
    {
        RedrawCell(element.position);

        Point direction = directionsMap[chosenAction];
        element.Move(direction, level);
    }
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);

void RedrawCell(Point position)
{
    Console.SetCursorPosition(position.x, position.y);
    string row = level[position.y];
    char cellValue = row[position.x];
    Console.Write(cellValue);
}