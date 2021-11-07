using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralManager : MonoBehaviour
{

    public List<SpawnableObject> spawnedObjects;

    public Transform spawnThreshold;

    public SimplePlatform simplePlatform;

    public float playerMaxY;

    public float playerMaxX;
    public Transform RightBound, LeftBound;

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
                
            float newObjectY = lastSpawnedObjectPosition.y + Random.Range(2, playerMaxY);
            float newObjectX = lastSpawnedObjectPosition.x + randomDirection* Random.Range(5, playerMaxX);
            
            Vector3 newObjectTransform = new Vector3(newObjectX,newObjectY,0);
            
            SpawnableObject newObject=Instantiate(simplePlatform, newObjectTransform, Quaternion.identity);
            Debug.Log("X: "+newObjectTransform.x+" EndX: "+newObject.EndX+" BoundX: "+rightBoundX);

            if (newObject.StartX<leftBoundX || newObject.EndX>rightBoundX)
            {
                Destroy(newObject.gameObject);
                Debug.Log("destroyed"+newObject);
                randomDirection *= -1;
                newObjectX = lastSpawnedObjectPosition.x + randomDirection* Random.Range(2, playerMaxX);
                newObjectTransform = new Vector3(newObjectX,newObjectY,0);
                newObject=Instantiate(simplePlatform, newObjectTransform, Quaternion.identity);
                Debug.Log("New Object X: "+newObjectTransform.x+" EndX: "+newObject.EndX+" BoundX: "+rightBoundX);

                
            }
            spawnedObjects.Add(newObject);
        }
        
    }
}
