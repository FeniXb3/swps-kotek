class NonPlayerCharacter : Character
{
    public NonPlayerCharacter(string name, string avatar) : base(name, avatar)
    {
    }

    public override string ChooseAction()
    {
        return "moveLeft";
    }
}