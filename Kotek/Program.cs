Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

Point startingPoint = new Point(16, 2);
Player hero = new Player("Snake", "@");
hero.speed = 1;
hero.position = startingPoint;

List<Character> characters = new List<Character>();
characters.Add(hero);

for (int i = 0; i < 5; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L");
    npc.position = new Point(5 + i, 5);
    characters.Add(npc);
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
    foreach (Character element in characters)
    {
        element.Display();
    }

    int charactersCount = characters.Count;
    for (int i = 0; i < charactersCount; i++)
    {
        Character element = characters[i];

        string chosenAction = element.ChooseAction();

        if (!directionsMap.ContainsKey(chosenAction))
        {
            if (chosenAction == "clone")
            {
                PlayerClone clone = new PlayerClone(hero, "C");
                clone.position = startingPoint;
                characters.Add(clone);
            }

            continue;
        }
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