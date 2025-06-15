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

    List<List<Cell>> levelData;

    public Level()
    {
        levelData = new List<List<Cell>>();
        for (int y = 0; y < levelVisuals.Length; y++)
        {
            List<Cell> row = new List<Cell>();
            for (int x = 0; x < levelVisuals[y].Length; x++)
            {
                char visuals = levelVisuals[y][x];
                Cell cell = new Cell(visuals);
                row.Add(cell);
            }
            levelData.Add(row);
        }
    }

    public void Display()
    {
        foreach (List<Cell> row in levelData)
        {
            foreach (Cell cell in row)
            {
                cell.Display();
            }
            Console.WriteLine();
        }
    }
    
    public void RedrawCell(Point position)
    {
        Console.SetCursorPosition(position.x, position.y);
        Cell cell = levelData[position.y][position.x];
        cell.Display();
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

    internal void OccupyCell(Point position, Character character)
    {
        Cell cell = GetCell(position.x, position.y);
        cell.Occupy(character);
    }

    public Cell GetCell(int x, int y)
    {
        return levelData[y][x];
    }
}