using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class ProceduralManager : MonoBehaviour
{

    public List<SpawnableObject> spawnedObjects;

    public Transform spawnThreshold;

    public SimplePlatform simplePlatform;

    public float playerMaxY;

    public float playerMaxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnableObject lastSpawnedObject=spawnedObjects[spawnedObjects.Count-1];

        Vector2 lastSpawnedObjectPosition = lastSpawnedObject.transform.position;
        if (lastSpawnedObject.transform.position.y < spawnThreshold.position.y)
        {
            Vector3 newObjectTransform = new Vector3(lastSpawnedObjectPosition.x,
                lastSpawnedObjectPosition.y + Random.Range(5, playerMaxY),0);
            SpawnableObject newObject=Instantiate(simplePlatform, newObjectTransform, Quaternion.identity);
            spawnedObjects.Add(newObject);
        }
        
    }
}
