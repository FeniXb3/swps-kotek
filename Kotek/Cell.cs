class Cell
{
    private char visuals;
    private Character occupant;

    public Cell(char visuals)
    {
        this.visuals = visuals;
    }

    public void Display()
    {
        Console.Write(visuals);
    }

    internal void Occupy(Character character)
    {
        occupant = character;
    }
}