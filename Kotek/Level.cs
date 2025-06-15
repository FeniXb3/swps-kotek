class Level
{
    string[] levelVisuals =
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

    public void Display()
    {
        foreach (string row in levelVisuals)
        {
            Console.WriteLine(row);
        }
    }
    
    public void RedrawCell(Point position)
    {
        Console.SetCursorPosition(position.x, position.y);
        string row = levelVisuals[position.y];
        char cellValue = row[position.x];
        Console.Write(cellValue);
    }

    public char GetCellVisuals(int x, int y)
    {
        return levelVisuals[y][x];
    }

    public int GetHeight()
    {
        return levelVisuals.Length;
    }

    public int GetRowWidth(int rowNumber)
    {
        return levelVisuals[rowNumber].Length;
    }
}