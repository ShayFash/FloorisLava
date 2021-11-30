
[System.Serializable]

public class EnemyData:SaveableData
{
    public int health;
  
    public PositionData posData;
    public EnemyData(int health,float x, float y)
    {
        this.health = health;
       
        posData = new PositionData(x, y);
    }
}
