using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ProceduralManager : MonoBehaviour
{

    public List<SpawnableObject> spawnedObjects;

    public List<EnemyPlatform> enemyPlatforms;

    public List<SimplePlatform> itemPlatforms;

    public Transform spawnThreshold;

    public SimplePlatform simplePlatform;

    public float playerMaxY;

    public float minReachRadius;
    public float maxReachRadius;

    public float playerMaxX;
    public Transform RightBound, LeftBound;
    private int counter;
    private float rightBoundX, leftBoundX;
    // Start is called before the first frame update
    void Start()
    {
        rightBoundX = RightBound.position.x;
        leftBoundX = LeftBound.position.x;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnableObject lastSpawnedObject=spawnedObjects[spawnedObjects.Count-1];

        Vector2 lastSpawnedObjectPosition = lastSpawnedObject.transform.position;
        if (lastSpawnedObject.transform.position.y < spawnThreshold.position.y)
        {
            int randomDirection = Random.Range(0, 2) * 2 - 1;


            
            SpawnableObject objectToSpawn;
            if (spawnedObjects.Count % (int) Random.Range(2, 5) == 0)
            {
                objectToSpawn = (enemyPlatforms[(int) Random.Range(0, enemyPlatforms.Count)]);
            }else if (spawnedObjects.Count % ((int) Random.Range(2, 5)) == 0)
            {
                objectToSpawn = itemPlatforms[(int) Random.Range(0, enemyPlatforms.Count)];
            }
            else
            {
                objectToSpawn = (SpawnableObject) simplePlatform;
            }
       
            
            SpawnableObject newObject=Instantiate(objectToSpawn, getNewSpawnPosition(lastSpawnedObjectPosition,randomDirection), Quaternion.identity);
            // Debug.Log("X: "+newObjectTransform.x+" EndX: "+newObject.EndX+" BoundX: "+rightBoundX);

            if (newObject.StartX<leftBoundX || newObject.EndX>rightBoundX)
            {
                Destroy(newObject.gameObject);
                newObject=Instantiate(objectToSpawn, getNewSpawnPosition(lastSpawnedObjectPosition,randomDirection*-1), Quaternion.identity);
                // Debug.Log("New Object X: "+newObjectTransform.x+" EndX: "+newObject.EndX+" BoundX: "+rightBoundX);
            }
            spawnedObjects.Add(newObject);
        }
        
    }

    private Vector3 getNewSpawnPosition(Vector2 lastSpawnedObjectPosition,int direction)
    {
        // float newObjectY = lastSpawnedObjectPosition.y + Random.Range(2, playerMaxY);
        float currentRadius = Random.Range(minReachRadius, maxReachRadius);
        float newObjectX = lastSpawnedObjectPosition.x+ direction*Random.Range(4, currentRadius);
        float newObjectY= (float)(Math.Sqrt(currentRadius*currentRadius - Math.Pow((newObjectX-lastSpawnedObjectPosition.x),2)) + lastSpawnedObjectPosition.y);
        
        return new Vector3(newObjectX,newObjectY,0);
    }
}
