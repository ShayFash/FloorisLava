using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlatform : SpawnableObject
{
    // Start is called before the first frame update
   
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override  SaveableData saveObject(){
        
        return new PositionData(transform.position.x,transform.position.y);
    }

    public override void loadObject(SaveableData data){
        PositionData positionData=data as PositionData;
        if(transform!=null)
            transform.position=positionData.getVector3();

    }

   
}
