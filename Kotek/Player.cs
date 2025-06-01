class Player : Character
{
    Dictionary<ConsoleKey, string> keyActionsMap = new Dictionary<ConsoleKey, string>
    {
        {ConsoleKey.A, "moveLeft"},
        {ConsoleKey.D, "moveRight"},
        {ConsoleKey.W, "moveUp"},
        {ConsoleKey.S, "moveDown"},
        {ConsoleKey.C, "clone"},
    };

    public Player(string name, string avatar) : base(name, avatar)
    {
    }

    public override string ChooseAction()
    {
        ConsoleKeyInfo pressedKeyInfo = Console.ReadKey(true);
        string chosenAction = keyActionsMap.GetValueOrDefault(pressedKeyInfo.Key, "pass");

        return chosenAction;
    }
}
