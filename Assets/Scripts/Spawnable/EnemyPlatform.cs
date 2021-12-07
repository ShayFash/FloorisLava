using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatform : SpawnableObject
{
     public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override SaveableData saveObject(){
        EnemyData enemyData=enemy.saveObject() as EnemyData;
        SaveableData saveableData=new EnemyPlatformData(enemyData,transform.position.x,transform.position.y);
        return saveableData;
    }
    
    public override void loadObject(SaveableData data){
        EnemyPlatformData enemyPlatformData= data as EnemyPlatformData;
        enemy.loadObject(enemyPlatformData.enemyData);
        transform.position=enemyPlatformData.posData.getVector3();

    }

}

