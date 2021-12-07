


[System.Serializable]

public class EnemyPlatformData:SaveableData
{
    public EnemyData enemyData;
  
    public PositionData posData;
    public EnemyPlatformData(EnemyData enemyData,float x, float y)
    {
        this.enemyData=enemyData;
      
        posData = new PositionData(x, y);
    }
}
