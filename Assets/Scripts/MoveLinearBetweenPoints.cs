using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLinearBetweenPoints : MonoBehaviour
{

    public List<Transform> points;

    private List<Transform> fixedPoints;
    private int visited = 0;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        fixedPoints = points;
        points.ForEach(p => p.SetParent(null));
    }

    private void FixedUpdate()
    {
        transform.position=Vector2.MoveTowards(transform.position, fixedPoints[visited].position, speed * Time.fixedDeltaTime);
        if (transform.position == fixedPoints[visited].position)
        {
            visited = (visited == (fixedPoints.Count - 1)) ? 0 : ++visited;
        }

    }
    
}