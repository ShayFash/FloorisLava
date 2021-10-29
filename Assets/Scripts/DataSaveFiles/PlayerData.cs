
[System.Serializable]

public class PlayerData:SaveableData
{
    public int health;
    public int money;
    public PositionData posData;
    public bool isLookingRight;
    public PlayerData(int health,int money,float x, float y,bool isLookingRight)
    {
        this.health = health;
        this.money = money;
        posData = new PositionData(x, y);
        this.isLookingRight = isLookingRight;
    }
}
