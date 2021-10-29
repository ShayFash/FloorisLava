using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class PickupItem:MonoBehaviour,Interactable,Saveable
{
    public void interact()
    {
        interactSpecific();
        gameObject.SetActive(false);
        
    }

    public abstract void interactSpecific();
    public SaveableData saveObject()
    {
        return new InteractiveObjectData(!this.gameObject.activeSelf);
    }

    public void loadObject(SaveableData data)
    {
        InteractiveObjectData potionData=data as InteractiveObjectData;;
        if (data!=null)
        {
            if (potionData.Open)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);

            }
        }
    }
}
