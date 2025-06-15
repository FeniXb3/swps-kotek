class NonPlayerCharacter : Character
{
    List<string> allowedActions;

    public NonPlayerCharacter(string name, string avatar, Point startingPoint, Level level) : base(name, avatar, startingPoint, level)
    {
        allowedActions = new List<string>
        {
            "moveLeft",
            "moveRight",
            "moveUp",
            "moveDown",
        };
    }

    public override string ChooseAction()
    {
        return allowedActions[Random.Shared.Next(allowedActions.Count)];
    }
}