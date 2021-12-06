
[System.Serializable]

public class PlayerData:SaveableData
{
    public int health;
    public int money;

    public int score;
    public PositionData posData;
    public bool isLookingRight;
    public PlayerData(int health,int money,int score,float x, float y,bool isLookingRight)
    {
        this.health = health;
        this.money = money;
        this.score=score;
        posData = new PositionData(x, y);
        this.isLookingRight = isLookingRight;
    }
}
