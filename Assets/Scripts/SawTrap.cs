using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : MonoBehaviour,Saveable
{
    [Range(0,10)]
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.Equals(PlayerAccess.getInstance()))
        {
            PlayerAccess.getStats().CurrentHealth -= damage;
        }
    }

    public SaveableData saveObject()
    {
        return new PositionData(transform.position.x, transform.position.y);
    }

    public void loadObject(SaveableData data)
    {
        PositionData positionData = data as PositionData;
        if (positionData != null)
        {
            transform.position = positionData.getVector3();
        }
    }
}
