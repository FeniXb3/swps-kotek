Dictionary<string, Point> directionsMap = new Dictionary<string, Point>();
directionsMap.Add("moveLeft", new Point(-1, 0));
directionsMap.Add("moveRight", new Point(1, 0));
directionsMap.Add("moveUp", new Point(0, -1));
directionsMap.Add("moveDown", new Point(0, 1));

Point startingPoint = new Point(16, 2);
Player hero = new Player("Snake", "@", startingPoint);
hero.speed = 1;

List<Character> characters = new List<Character>();
characters.Add(hero);

for (int i = 0; i < 5; i++)
{
    NonPlayerCharacter npc = new NonPlayerCharacter("Liquid", "L", new Point(5 + i, 5));
    characters.Add(npc);
}

Level firstLevel = new Level();

firstLevel.Display();

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
                PlayerClone clone = new PlayerClone(hero, "C", startingPoint);
                characters.Add(clone);
            }

            continue;
        }
        firstLevel.RedrawCell(element.Position);

        Point direction = directionsMap[chosenAction];
        element.Move(direction, firstLevel);
    }
}

Console.WriteLine("Press Space to continue...");
ConsoleKeyInfo keyInfo;

do
{
    keyInfo = Console.ReadKey(true);
} while (keyInfo.Key != ConsoleKey.Spacebar);
