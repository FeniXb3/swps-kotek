
class Cell
{
    private char visuals;

    public Cell(char visuals)
    {
        this.visuals = visuals;
    }

    public void Display()
    {
        Console.Write(visuals);
    }
}