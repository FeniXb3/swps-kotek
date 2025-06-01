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

List<NonPlayerCharacter> npcs = new List<NonPlayerCharacter>();
for (int i = 0; i < 5; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L");
    npc.position = new Point(5 + i, 5);
    npcs.Add(npc);
}

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

    foreach (NonPlayerCharacter npc in npcs)
    {
        npc.Display();
    }

    string chosenAction = hero.ChooseAction();

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

    foreach (NonPlayerCharacter npc in npcs)
    {
        string npcAction = npc.ChooseAction();
        RedrawCell(npc.position);
        Point npcDirection = directionsMap[npcAction];
        npc.Move(npcDirection, level);
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