
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void saveData(List<Saveable> objectsToSave)
    {
        string path = Application.persistentDataPath + "/data.sav";
        FileStream fileStream = new FileStream(path,FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        AllData allData = new AllData(objectsToSave.Count);
        for (int i = 0; i < objectsToSave.Count; i++)
        {
            allData.SaveableDatas[i] = objectsToSave[i].saveObject();
        }
        binaryFormatter.Serialize(fileStream,allData);
        fileStream.Close();
        Debug.Log("Saved");
    }

    public static void loadData(List<Saveable> objectsToLoad)
    { 
        string path = Application.persistentDataPath + "/data.sav";
        FileStream fileStream = new FileStream(path,FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        AllData data=binaryFormatter.Deserialize(fileStream) as AllData;
        for (int i = 0; i < objectsToLoad.Count; i++)
        {
            objectsToLoad[i].loadObject(data.SaveableDatas[i]);
        }
        fileStream.Close();
        
    }
}
