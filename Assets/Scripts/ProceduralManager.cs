using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ProceduralManager : MonoBehaviour,Saveable
{

    public List<SpawnableObject> spawnedObjects;

    public List<EnemyPlatform> enemyPlatforms;

    public List<SimplePlatform> itemPlatforms;

    public Transform spawnThreshold;

    public SimplePlatform simplePlatform;

    public float playerMaxY;

    public float minReachRadius;
    public float maxReachRadius;

    private int lastEnemySpawned=2, lastItemSpawned=0;
    public float playerMaxX;
    public Transform RightBound, LeftBound;
    private int counter;
    private float rightBoundX, leftBoundX;

    public GameObject spawnedParent;

    public float minHorizontalDistanceBetweenPlatforms = 6f;
    // Start is called before the first frame update
    void Start()
    {
        rightBoundX = RightBound.position.x;
        leftBoundX = LeftBound.position.x;
        
        
    }

    private SpawnableObject getRandomSpawnableObject()
    {
        SpawnableObject objectToSpawn;

        if (spawnedObjects.Count - lastEnemySpawned > Random.Range(4, 6))
        {
            lastEnemySpawned = spawnedObjects.Count;
            objectToSpawn = (enemyPlatforms[(int) Random.Range(0, enemyPlatforms.Count)]);

        }
       else if (spawnedObjects.Count - lastItemSpawned > Random.Range(4, 6))
        {
            lastItemSpawned = spawnedObjects.Count;
            objectToSpawn = itemPlatforms[(int) Random.Range(0, itemPlatforms.Count)];
        }
        else
        {
            objectToSpawn = (SpawnableObject) simplePlatform;
        }

        return objectToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnableObject lastSpawnedObject;

        
        if (spawnedObjects.Count>1&&spawnedObjects[spawnedObjects.Count - 1].transform.position.y <
            spawnedObjects[spawnedObjects.Count - 2].transform.position.y)
        {
            lastSpawnedObject = spawnedObjects[spawnedObjects.Count - 2];
        }
        else
        {
            lastSpawnedObject = spawnedObjects[spawnedObjects.Count - 1];
        }

        Vector2 lastSpawnedObjectPosition = lastSpawnedObject.transform.position;
        if (lastSpawnedObject.transform.position.y < spawnThreshold.position.y)
        {


            
            

            int numToSpawn = Random.Range(1, 3);
            numToSpawn = 2; //change it later
            int randomDirection = Random.Range(0, 2) * 2 - 1;
            int changeDirection = (numToSpawn > 1) ? -1 : 1;
            int counter = 0;
            while (counter < numToSpawn)
            {
                SpawnableObject objectToSpawn=getRandomSpawnableObject();


                SpawnableObject newObject = Instantiate(objectToSpawn,
                    getNewSpawnPosition(lastSpawnedObjectPosition, randomDirection*changeDirection,numToSpawn,counter), Quaternion.identity);
                // Debug.Log("X: "+newObjectTransform.x+" EndX: "+newObject.EndX+" BoundX: "+rightBoundX);

                if (newObject.StartX < leftBoundX || newObject.EndX > rightBoundX)
                {
                    Destroy(newObject.gameObject);
                    newObject = Instantiate(objectToSpawn,
                        getNewSpawnPosition(lastSpawnedObjectPosition, randomDirection *changeDirection* -1,numToSpawn,counter), Quaternion.identity);
                    newObject.transform.SetParent(spawnedParent.transform);
                    spawnedObjects.Add(newObject);
                    SaveManagerAccess.getInstance().addSaveableObject(newObject.gameObject.GetComponent<Saveable>());
                    break;
                    // Debug.Log("New Object X: "+newObjectTransform.x+" EndX: "+newObject.EndX+" BoundX: "+rightBoundX);
                }
                
                SaveManagerAccess.getInstance().addSaveableObject(newObject.gameObject.GetComponent<Saveable>());
                newObject.transform.SetParent(spawnedParent.transform);
                spawnedObjects.Add(newObject);
                changeDirection *= -1;
                counter++;
            }
        }
        
    }

    private Vector3 getNewSpawnPosition(Vector2 lastSpawnedObjectPosition,int direction,int numToSpawn,int counter)
    {
        // float newObjectY = lastSpawnedObjectPosition.y + Random.Range(2, playerMaxY);
        float currentRadius = Random.Range(minReachRadius, maxReachRadius);
        float newObjectX = 0;
        if (numToSpawn == 2 && counter == 1)
        {
            SpawnableObject lastSpawnedObject = spawnedObjects[spawnedObjects.Count - 1];
             newObjectX = lastSpawnedObject.transform.position.x+ direction*currentRadius;
             if (newObjectX - lastSpawnedObjectPosition.x < minHorizontalDistanceBetweenPlatforms)
             {

                 newObjectX = lastSpawnedObjectPosition.x + direction * Random.Range(minHorizontalDistanceBetweenPlatforms, currentRadius);
             }
        }
        else
        {
             newObjectX = lastSpawnedObjectPosition.x + direction * Random.Range(minHorizontalDistanceBetweenPlatforms, currentRadius);
        }




        float newObjectY= (float)(Math.Abs(Math.Sqrt(currentRadius*currentRadius - Math.Pow((newObjectX-lastSpawnedObjectPosition.x),2))) + lastSpawnedObjectPosition.y);
        if (newObjectY < lastSpawnedObjectPosition.y)
        {
            Debug.Log("Whats up "+gameObject);
        }
        return new Vector3(newObjectX,newObjectY,0);
    }

    public SaveableData saveObject(){
        List<SaveableData> dataToSave=new List<SaveableData>();
        List<SaveableKey> keysToSave=new List<SaveableKey>();
        foreach(Transform spawnedObject in spawnedParent.transform){
            EnemyPlatform enemyPlatform= spawnedObject.GetComponent<EnemyPlatform>();
            if(enemyPlatform!=null){
                keysToSave.Add(SaveableKey.ENEMY_PLATFORM);
                dataToSave.Add(enemyPlatform.saveObject());
            }else{
            SimplePlatform simplePlatform= spawnedObject.GetComponent<SimplePlatform>();
                if(simplePlatform!=null){

                keysToSave.Add(SaveableKey.SIMPLE_PLATFORM);
                dataToSave.Add(simplePlatform.saveObject());

                }
            }
        }

        return null;
    }

    public void loadObject(SaveableData data){
        
    }

}
