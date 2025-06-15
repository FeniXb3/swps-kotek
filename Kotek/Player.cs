class Player : Character
{
    public string chosenAction;
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
        chosenAction = keyActionsMap.GetValueOrDefault(pressedKeyInfo.Key, "pass");

        return chosenAction;
    }
}
