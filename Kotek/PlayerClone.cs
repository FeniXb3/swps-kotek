class PlayerClone : Player
{
    Player whosClone;
    List<string> allowedActions;

    public PlayerClone(Player whosClone, string avatar) : base(whosClone.name, avatar)
    {
        this.whosClone = whosClone;
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
        if (!allowedActions.Contains(whosClone.chosenAction))
        {
            return "pass";
        }
        
        return whosClone.chosenAction;
    }
}