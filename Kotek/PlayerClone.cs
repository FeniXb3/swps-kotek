class PlayerClone : Player
{
    Player whosClone;

    public PlayerClone(Player whosClone, string avatar) : base(whosClone.name, avatar)
    {
        this.whosClone = whosClone;
    }

    public override string ChooseAction()
    {
        return whosClone.chosenAction;
    }
}