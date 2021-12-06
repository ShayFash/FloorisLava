using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateGraph : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updatePath()
    {
        AstarPath.active.Scan();
    }
}
