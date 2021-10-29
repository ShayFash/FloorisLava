
using UnityEngine;

[System.Serializable]
public class PositionData:SaveableData
{
    public float x;
    public float y;

    public PositionData(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector3 getVector3()
    {
        return new Vector3(x, y, 0f);
    }
}

