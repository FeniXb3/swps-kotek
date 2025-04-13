class Player
{
    public string name;
    public Point position;
    public int speed = 1;
    public string avatar;

    public Player(string name, string avatar)
    {
        this.name = name;
        this.avatar = avatar;
    }
}

/*
Klasa Player:
 - dane:
    - hp
    - maxHp
    - attackStrength
    - stamina
    - maxStamina
    - name
    - position
    - inventory
 - akcje:
    - attack
    - heal
    - move
    - pickUpItem
    - useItem
*/