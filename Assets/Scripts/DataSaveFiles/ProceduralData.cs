
using UnityEngine;

[System.Serializable]
public class ProceduralData:SaveableData
{
    public SaveableData[] saveableData;
    public SaveableKey[] saveableKeys;

    public ProceduralData(SaveableData[] saveableData, SaveableKey[] saveableKeys)
    {
        this.saveableData = saveableData;
        this.saveableKeys = saveableKeys;
    }
}